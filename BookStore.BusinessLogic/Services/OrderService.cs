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

        public OrderService(IOrderRepository orderRepository,
                       IOrderItemsRepository orderItemsRepository,
                       IPrintingEditionRepository printingEditionRepository)
        {
            _orderRespository = orderRepository;
            _orderItemsRepository = orderItemsRepository;
            _printingEditionRepository = printingEditionRepository;


        }

        public async Task AddOrder(OrderModel orderModel)
        {
            Order order = orderModel.OrderMapToEntity();
            //order.Payment = new Payment();
            //order.User = new User();
            await _orderRespository.Create(order);
            foreach(OrderItemsModel orderItem in orderModel.OrderItemsModel)
            {
                PrintingEdition printingEdition = await _printingEditionRepository.Read(orderItem.PrintingEditionId);
                await _orderItemsRepository.Create(new OrderItems { Amount = orderItem.Amount,
                    Count = orderItem.Count,
                    Currency = orderItem.Currency,
                    PrintingEdition = printingEdition,
                    Order = orderModel.OrderMapToEntity() });
            }
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
