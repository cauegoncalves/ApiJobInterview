using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using cgds.manufacture.application.Entities;
using cgds.manufacture.application.Interfaces;

namespace cgds.manufacture.reposity.inmemory
{
    public class OrderRepository : IOrderRepository
    {

        
        private IDictionary<int, Order> orderTable;

        public OrderRepository()
        {
            orderTable = new ConcurrentDictionary<int, Order>();
        }

        public Order GetById(int id)
        {
            if (orderTable.TryGetValue(id, out var order))
                return order;

            return null;
        }

        public void Save(Order order)
        {
            if (orderTable.ContainsKey(order.OrderId))
                orderTable.Remove(order.OrderId);

            orderTable.Add(order.OrderId, order);
        }

    }
}
