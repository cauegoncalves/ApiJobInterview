using System;
using System.Collections.Generic;
using cgds.manufacture.application.Entities;
using cgds.manufacture.application.Interfaces;

namespace cgds.manufacture.reposity.inmemory
{
    public class OrderRepository : IOrderRepository
    {

        private Dictionary<int, Order> orderTable;

        public OrderRepository()
        {
            orderTable = new Dictionary<int, Order>();
        }

        public Order GetById(int id)
        {
            return orderTable.GetValueOrDefault(id, null);
        }

        public void Save(Order order)
        {
            lock (orderTable)
            {
                if (orderTable.ContainsKey(order.OrderId))
                    orderTable.Remove(order.OrderId);

                orderTable.Add(order.OrderId, order);
            }
        }

    }
}
