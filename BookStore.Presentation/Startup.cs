
using BookStore.BusinessLogic;
using BookStore.BusinessLogic.Autinfication;
using BookStore.BusinessLogic.Autinfication.Interfaces;
using BookStore.BusinessLogic.Services;
using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Stripe;
using System;


namespace BookStore.Presentation
{
    public class Startup
    {
        private string ConnectionString { get; set; }

        public IConfiguration Configuration { get; }

        public string GetConnectionString()
        {
            return ConnectionString;
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
                
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TestAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevelopmentConnectionString")));

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<TestAppContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }
            );

            DependencyInjection.InjectDependency(services);
            string securetyKey = Configuration["JWTConfig: SigningSecurityKey"];

            services.AddSingleton<IJwtSigningEncodingKey>(new SigningSymmetricKey("sdffvbferge3t223vgev34erbg44bgvrt3r43rv23fv2r"));

            services.AddTransient<UserService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            const string jwtSchemeName = "JwtBearer";

            var signingDecodingKey = ((IJwtSigningEncodingKey)(new SigningSymmetricKey("sdffvbferge3t223vgev34erbg44bgvrt3r43rv23fv2r")));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = jwtSchemeName;
                options.DefaultChallengeScheme = jwtSchemeName;
            }).AddJwtBearer(jwtSchemeName, jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingDecodingKey.GetKey(),

                    ValidateIssuer = false,
                    ValidIssuer = "webApi",

                    ValidateAudience = false,
                    ValidAudience = "client",

                    ValidateLifetime = true,

                    ClockSkew = TimeSpan.FromSeconds(5)
                };
            });

            services.AddTransient<RoleManager<Role>>();

            services.AddCors();

            

        }




        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                ConnectionString = Configuration.GetConnectionString("DevelopmentConnectionString");
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            MyIdentityDataInitializer.SeedRoles(roleManager).Wait();
            MyIdentityDataInitializer.SeedUsers(userManager).Wait();
            app.UseStaticFiles();
            //app.Run(async (context) => { await context.Response.WriteAsync("hello world"); });
            //app.UseMvc();
           
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
            
            //app.UseCors(builder =>
            //{
            //    builder.WithOrigins("http://localhost:4200")
            //    .AllowAnyMethod()
            //    .AllowAnyHeader();
            //});


        }
    }
}
