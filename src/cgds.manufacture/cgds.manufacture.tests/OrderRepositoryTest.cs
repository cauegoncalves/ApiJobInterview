using System;
using System.Collections.Generic;
using cgds.manufacture.application.Entities;
using cgds.manufacture.application.Factories;
using cgds.manufacture.application.Interfaces;
using cgds.manufacture.reposity.inmemory;
using NUnit.Framework;

namespace cgds.manufacture.tests
{

    [TestFixture]
    public class OrderRepositoryTest
    {
        IOrderRepository orderRepository;

        [SetUp]
        public void Setup()
        {
            orderRepository = new OrderRepository();
        }

        [Test]
        public void GetById_WhenIdNotExists_ShouldReturnNull()
        {
            Assert.IsNull(orderRepository.GetById(99));
        }

        [Test]
        public void GetById_WhenIdExists_ShouldReturnOrder()
        {
            var order = new Order(1, new List<OrderItem>());
            orderRepository.Save(order);
            Assert.AreSame(orderRepository.GetById(1), order);
        }

        [Test]
        public void Save_WhenSaveOrder_ShouldSucceded()
        {
            var order = new Order(1, new List<OrderItem> { new OrderItem(new CardFactory().Create(), 10) });
            orderRepository.Save(order);
            Assert.AreSame(orderRepository.GetById(1), order);
        }

        [Test]
        public void Save_WhenSaveOrderWithSameId_ShouldOverrideOrder()
        {
            var order1 = new Order(1, new List<OrderItem> { new OrderItem(new CardFactory().Create(), 10) });
            orderRepository.Save(order1);
            Assert.AreSame(orderRepository.GetById(1), order1);

            var order2 = new Order(1, new List<OrderItem> { new OrderItem(new MugFactory().Create(), 5) });
            orderRepository.Save(order2);
            Assert.AreSame(orderRepository.GetById(1), order2);
        }

    }
}