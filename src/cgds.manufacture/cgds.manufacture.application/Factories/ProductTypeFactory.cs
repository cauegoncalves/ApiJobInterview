using System;
using System.Collections.Generic;
using cgds.manufacture.application.Entities;
using cgds.manufacture.application.Enums;
using cgds.manufacture.application.Interfaces;

namespace cgds.manufacture.application.Factories
{
    public class ProductTypeFactory
    {

        private static Dictionary<EnumProductType, Type> factories = new Dictionary<EnumProductType, Type>()
        {
            { EnumProductType.calendar, typeof(CalendarFactory) },
            { EnumProductType.canvas , typeof(CanvasFactory) },
            { EnumProductType.cards, typeof(CardFactory) },
            { EnumProductType.mug, typeof(MugFactory) },
            { EnumProductType.photoBook, typeof(PhotoBookFactory) },
        };

        public static ProductType Create(EnumProductType type)
        {
            IProductTypeFactory factory = (IProductTypeFactory)Activator.CreateInstance(factories[type]);
            return factory.Create();
        }
    }
}
