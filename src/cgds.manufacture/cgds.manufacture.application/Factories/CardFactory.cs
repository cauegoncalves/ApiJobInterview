using System;
using cgds.manufacture.application.Entities;
using cgds.manufacture.application.Interfaces;

namespace cgds.manufacture.application.Factories
{
    public class CardFactory : IProductTypeFactory
    {

        public ProductType Create() => new CardProductType();
    }
}
