using System;
using System.Collections.Generic;
using cgds.manufacture.api.Models.Order;
using cgds.manufacture.application.Entities;
using cgds.manufacture.application.Factories;

namespace cgds.manufacture.api.Extensions
{
    public static class ConvertModelsExtensions
    {

        public static Order ToOrder(this OrderRequest orderRequest)
        {
            var order = new Order(
                orderRequest.OrderId.Value,
                orderRequest.Items.ToOrderItems());
            return order;
        }

        public static List<OrderItem> ToOrderItems(this List<OrderItemDTO> orderItemDTOs)
        {
            var converter = new Converter<OrderItemDTO, OrderItem>(
                (o) => new OrderItem()
                        {
                            Product = ProductTypeFactory.Create(o.ProductType),
                            Quantity = o.Quantity,
                        });
            return orderItemDTOs.ConvertAll(converter);
        }

        public static List<OrderItemDTO> ToOrderItemsDTO(this List<OrderItem> orderItems)
        {
            var converter = new Converter<OrderItem, OrderItemDTO>(
                (o) => new OrderItemDTO()
                        {
                            ProductType = o.Product.Type,
                            Quantity = o.Quantity,
                        });
            return orderItems.ConvertAll(converter);
        }
    }
}