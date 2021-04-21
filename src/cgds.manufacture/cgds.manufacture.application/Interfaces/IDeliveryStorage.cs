using System;
using System.Collections.Generic;
using cgds.manufacture.application.Entities;

namespace cgds.manufacture.application.Interfaces
{
    public interface IDeliveryStorage
    {
        decimal CalculateStorageWidth(List<OrderItem> orderItems);
    }
}