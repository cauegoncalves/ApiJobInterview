using System;
using System.Collections.Generic;
using cgds.manufacture.api.Extensions;

namespace cgds.manufacture.api.Models.Order
{
    public class OrderResponse
    {
        public OrderResponse(){}

        public OrderResponse(application.Entities.Order order)
        {
            this.Items = order.Items.ToOrderItemsDTO();
            this.RequiredBinWidth = order.StorageWidth;
        }

        public List<OrderItemDTO> Items { get; set; }

        public decimal RequiredBinWidth { get; set; }

    }
}
