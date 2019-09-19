
using BookStore.BusinessLogic.Services;
using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BookStore.Presentation
{
    public class Startup
    {
        private string ConnectionString { get; set; }

        public string GetConnectionString()
        {
            return ConnectionString;
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TestAppContext>(options => options.UseSqlServer(GetConnectionString()));

            services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<TestAppContext>();

            services.AddTransient<UserService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                ConnectionString = Configuration.GetConnectionString("DevelopmentConnectionString");
            }
            else
            {
               
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication(); 
            app.UseStaticFiles();
            app.Run(async (context) => { await context.Response.WriteAsync("hello world"); });
            app.UseMvc();
        }
    }
}
