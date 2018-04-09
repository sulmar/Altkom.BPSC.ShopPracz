using System;
using Altkom.BPSC.ShopPracz.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Altkom.BPSC.ShopPracz.UnitTests
{
    [TestClass]
    public class OrderUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateOrderWithNullCustomerTest()
        {
            // Arrange
            Customer customer = null;

            Order order = new Order("ZAM 1/2018", customer);


        }

        [TestMethod]
        public void CreateOrderTest()
        {

            // Arrange

            Customer customer = new Customer();

            Order order = new Order("ZAM 1/2018", customer);

            // Acts

            string fullname = order.Customer.FullName;

            // Assert

            Assert.IsNotNull(order);
            Assert.IsNotNull(order.Customer);
            Assert.AreEqual(OrderStatus.Draft, order.Status);
            Assert.AreEqual(DateTime.Today, order.OrderDate.Date);
            Assert.IsFalse(string.IsNullOrEmpty(order.OrderNumber), "Numer zamówienia nie może być pusty");

        }
    }
}
