using System;
using System.Collections.Generic;
using cgds.manufacture.application.Entities;
using cgds.manufacture.application.Factories;
using cgds.manufacture.application.Interfaces;
using cgds.manufacture.application.Services;
using cgds.manufacture.reposity.inmemory;
using cgds.manufacture.service.simplifieddeliverystorage;
using NUnit.Framework;

namespace cgds.manufacture.tests
{

    [TestFixture]
    public class OrderFacadeTest
    {
        IOrderService orderService;
        IOrderRepository orderRepository;
        IDeliveryStorage deliveryStorage;

        [SetUp]
        public void SetUp()
        {
            orderRepository = new OrderRepository();
            deliveryStorage = new SimplifiedDeliveryStorage();
            orderService = new OrderFacade(orderRepository, deliveryStorage);
        }

        [TestCaseSource(nameof(GenerateStorageWidthTestCases))]
        public void Save_WhenInputIsParameterOrderItemsParameter_ShouldReturnExpectedParameter(StorageWidthTestCase testCase)
        {
            var order = new Order(new Random().Next(), testCase.OrderItems);
            Assert.AreEqual(orderService.Save(order), testCase.ExpectedResult);
        }

        private static IEnumerable<StorageWidthTestCase> GenerateStorageWidthTestCases()
        {
            yield return new StorageWidthTestCase(new List<OrderItem>() {
                new OrderItem(new PhotoBookFactory().Create(), 1),
                new OrderItem(new CalendarFactory().Create(), 2),
                new OrderItem(new MugFactory().Create(), 2),
            }, expectedResult: 19 + 10 + 10 + 94);
            yield return new StorageWidthTestCase(new List<OrderItem>() {
                new OrderItem(new PhotoBookFactory().Create(), 1),
                new OrderItem(new CalendarFactory().Create(), 2),
                new OrderItem(new MugFactory().Create(), 4),
            }, expectedResult: 19 + 10 + 10 + 94);
            yield return new StorageWidthTestCase(new List<OrderItem>() {
                new OrderItem(new PhotoBookFactory().Create(), 1),
                new OrderItem(new CalendarFactory().Create(), 2),
                new OrderItem(new MugFactory().Create(), 5),
            }, expectedResult: 19 + 10 + 10 + 94 + 94);
            yield return new StorageWidthTestCase(new List<OrderItem>()
            {
                new OrderItem(new CanvasFactory().Create(), 1),
                new OrderItem(new CardFactory().Create(), 1)
            }, expectedResult: 16 + 4.7M);
        }

    }

}