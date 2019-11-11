using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services.Intefaces;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class OrderService: IOrderService
    {
        public IOrderRepository _orderRespository;
        public IOrderItemsRepository _orderItemsRepository;
        public IPrintingEditionRepository _printingEditionRepository;
        public IPaymentRepository _paymentRepository;

        public OrderService(IOrderRepository orderRepository,
                       IOrderItemsRepository orderItemsRepository,
                       IPrintingEditionRepository printingEditionRepository,
                       IPaymentRepository paymentRepository)
        {
            _orderRespository = orderRepository;
            _orderItemsRepository = orderItemsRepository;
            _printingEditionRepository = printingEditionRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task AddOrder(OrderModel orderModel)
        {
            Order order = orderModel.OrderMapToEntity();
            order.UserId = orderModel.UserId;
            var orderId = await _orderRespository.GetIdAfterCreate(order);
            foreach (OrderItemsModel orderItem in orderModel.OrderItemsModel)
            {
                PrintingEdition printingEdition = await _printingEditionRepository.Read(orderItem.PrintingEditionId);
                await _orderItemsRepository.Create(new OrderItems
                {
                    Amount = orderItem.Amount,
                    Count = orderItem.Count,
                    Currency = orderItem.Currency,
                    OrderId = orderId,
                    PrintingEditionId = orderItem.PrintingEditionId

                });
                    
            }
            Payment payment = new Payment();
            payment.TransactionId = orderModel.StripeToken;
            payment.OrderId = orderId;
            await _paymentRepository.GetIdAfterCreate(payment);

        }

        public async Task<int> GetOrderTotalCoastInCents(OrderModel orderModel)
        {
            int totalPrice=0;
            foreach (OrderItemsModel orderItems in orderModel.OrderItemsModel)
            {
                totalPrice += await _printingEditionRepository.GetPriceInCentes(orderItems.PrintingEditionId) * orderItems.Amount;
            }
            return totalPrice;
        }
        public async Task<List<OrderModel>> GetAllOrders()
        {
            List<OrderModel> OrdersModel = new List<OrderModel>();
            List<Order> OrdersEntity = await _orderRespository.ReadAll();
            foreach(Order order in OrdersEntity)
            {
                OrdersModel.Add(new OrderModel(order));
            }
            return OrdersModel;
        }
    }
}
