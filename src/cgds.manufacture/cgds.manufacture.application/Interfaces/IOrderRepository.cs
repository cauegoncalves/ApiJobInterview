using System;
using cgds.manufacture.application.Entities;

namespace cgds.manufacture.application.Interfaces
{
    public interface IOrderRepository
    {

        void Save(Order order);
        Order GetById(int id);

    }
}
