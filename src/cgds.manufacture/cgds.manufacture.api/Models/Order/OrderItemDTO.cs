using System;
using cgds.manufacture.application.Enums;

namespace cgds.manufacture.api.Models.Order
{
    public class OrderItemDTO
    {
        public EnumProductType ProductType { get; set; }
        public int Quantity { get; set; }
    }
}
