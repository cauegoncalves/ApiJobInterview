using System;
using System.Collections.Generic;
using System.Linq;
using cgds.manufacture.application.Entities;
using cgds.manufacture.application.Interfaces;

namespace cgds.manufacture.service.simplifieddeliverystorage
{
    public class SimplifiedDeliveryStorage : IDeliveryStorage
    {
        public decimal CalculateStorageWidth(List<OrderItem> orderItems)
        {
            var totalWidth = 0M;
            if (orderItems != null)
            {
                foreach (var item in AggregateOrderItems(orderItems))
                {
                    var itemWidth = 0M;

                    if (item.Product.CanStack)
                    {
                        var numberOfStacks = (decimal)item.Quantity / (decimal)item.Product.StackLimit;
                        itemWidth = item.Product.PackageWidth * Math.Ceiling(numberOfStacks);
                    }
                    else
                        itemWidth = item.Product.PackageWidth * item.Quantity;

                    totalWidth += itemWidth;
                }
            }
            return totalWidth;
        }

        private IEnumerable<OrderItem> AggregateOrderItems(List<OrderItem> orderItems)
        {
            return orderItems.GroupBy(o => o.Product.Type)
                    .Select(og => new OrderItem
                    {
                        Product = og.First().Product,
                        Quantity = og.Sum(o => o.Quantity)
                    });
        }

    }
}
