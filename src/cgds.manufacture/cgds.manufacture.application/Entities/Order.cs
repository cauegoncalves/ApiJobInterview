using System;
using System.Collections.Generic;
using cgds.manufacture.application.Interfaces;

namespace cgds.manufacture.application.Entities
{
    public class Order
    {
        public Order(int orderId, List<OrderItem> items)
        {
            OrderId = orderId;
            Items = items;
        }

        public int OrderId { get; set; }

        public List<OrderItem> Items { get; set; }

        public decimal StorageWidth { get; internal set; }

    }
}