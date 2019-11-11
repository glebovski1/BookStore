using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services;
using BookStore.BusinessLogic.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace BookStore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IOrderService _orderService;

        public PaymentController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("AddOrder")]
        [Authorize(Roles="Admin, User")]
        public async Task AddOrder([FromBody]OrderModel orderModel)
        {
            Dictionary<string, string> Metadata = new Dictionary<string, string>();
            Metadata.Add("Product", "Printing Editions");
            Metadata.Add("Quantity", "");
            var options = new ChargeCreateOptions
            {
                Amount = await _orderService.GetOrderTotalCoastInCents(orderModel),
                Currency = "USD",
                Description = "Buying Printing Editions",
                Source = orderModel.StripeToken,
                //ReceiptEmail = orderModel.Email,
                Metadata = Metadata
                

                
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);
            await _orderService.AddOrder(orderModel);
        }
    }
}