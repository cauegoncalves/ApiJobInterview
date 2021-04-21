using System;
namespace cgds.manufacture.application.Entities
{
    public class OrderItem
    {

        public OrderItem()
        {

        }

        public OrderItem(ProductType product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public ProductType Product { get; set; }

        public int Quantity { get; set; }

    }
}
