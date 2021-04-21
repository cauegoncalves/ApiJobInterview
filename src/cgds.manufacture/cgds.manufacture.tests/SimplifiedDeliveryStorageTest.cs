using System.Collections.Generic;
using cgds.manufacture.application.Entities;
using cgds.manufacture.application.Factories;
using cgds.manufacture.application.Interfaces;
using cgds.manufacture.service.simplifieddeliverystorage;
using NUnit.Framework;

namespace cgds.manufacture.tests
{

    [TestFixture]
    public class SimplifiedDeliveryStorageTest
    {

        IDeliveryStorage deliveryStorageService;

        [OneTimeSetUp]
        public void Setup()
        {
            deliveryStorageService = new SimplifiedDeliveryStorage();
        }

        [Test]
        public void CalculateStorageWidth_WhenOrderItemsIsEmpty_ShouldReturnZero()
        {
            Assert.AreEqual(deliveryStorageService.CalculateStorageWidth(new List<OrderItem>()), 0);
        }

        [Test]
        public void CalculateStorageWidth_WhenOrderItemsIsNull_ShouldReturnZero()
        {
            Assert.AreEqual(deliveryStorageService.CalculateStorageWidth(null), 0);
        }

        [TestCaseSource(nameof(GenerateStorageWidthTestCases))]
        public void CalculateStorageWidth_WhenInputIsParameterOrderItemsParameter_ShouldReturnExpectedParameter(StorageWidthTestCase testCase)
        {
            Assert.AreEqual(deliveryStorageService.CalculateStorageWidth(testCase.OrderItems), testCase.ExpectedResult);
        }

        public void CalculateStorageWidth_WhenOrderItemsHasDuplicatedItems_ShouldAggregate()
        {
            var testCase = new StorageWidthTestCase(new List<OrderItem>() {
                new OrderItem(new MugFactory().Create(), 1),
                new OrderItem(new MugFactory().Create(), 2),
                new OrderItem(new MugFactory().Create(), 1),
            }, expectedResult: 94);
            Assert.AreEqual(deliveryStorageService.CalculateStorageWidth(testCase.OrderItems), testCase.ExpectedResult);
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