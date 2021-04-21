using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cgds.manufacture.api.Models.Order
{
    public class OrderRequest
    {
        [Required(ErrorMessage = "OrderId is required.")]
        public int? OrderId { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
