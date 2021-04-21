using System;
using System.Collections.Generic;
using cgds.manufacture.application.Entities;

namespace cgds.manufacture.tests
{

    public class StorageWidthTestCase
    {
        public StorageWidthTestCase(List<OrderItem> orderItems, decimal expectedResult)
        {
            OrderItems = orderItems;
            ExpectedResult = expectedResult;
        }

        public List<OrderItem> OrderItems { get; set; }
        public decimal ExpectedResult { get; set; }
    }

}
