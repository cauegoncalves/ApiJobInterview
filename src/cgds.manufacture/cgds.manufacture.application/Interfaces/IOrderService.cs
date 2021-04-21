using System;
using cgds.manufacture.application.Entities;

namespace cgds.manufacture.application.Interfaces
{
    public interface IOrderService
    {

        decimal Save(Order order);

    }
}
