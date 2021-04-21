using System;
using cgds.manufacture.application.Entities;
using cgds.manufacture.application.Interfaces;

namespace cgds.manufacture.application.Services
{
    public class OrderFacade : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IDeliveryStorage deliveryStorage;

        public OrderFacade(IOrderRepository orderRepository, IDeliveryStorage deliveryStorage)
        {
            this.orderRepository = orderRepository;
            this.deliveryStorage = deliveryStorage;
        }

        public decimal Save(Order order)
        {
            order.StorageWidth = deliveryStorage.CalculateStorageWidth(order.Items);
            orderRepository.Save(order);
            return order.StorageWidth;
        }

    }
}
