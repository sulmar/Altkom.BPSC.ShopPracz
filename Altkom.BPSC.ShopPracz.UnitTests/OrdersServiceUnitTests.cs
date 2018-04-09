using System;
using Altkom.BPSC.ShopPracz.DbServices;
using Altkom.BPSC.ShopPracz.IServices;
using Altkom.BPSC.ShopPracz.MockServices;
using Altkom.BPSC.ShopPracz.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Altkom.BPSC.ShopPracz.UnitTests
{
    [TestClass]
    public class OrdersServiceUnitTests
    {
        [TestMethod]
        public void AddTest()
        {
            // Arrange

            Customer customer = new Customer();
            Order order = new Order("ZAM 1/2018", customer);

            IOrdersService ordersService = new MockOrdersService();
            
            // Acts
            ordersService.Add(order);

            // Asserts
            Order addedOrder = ordersService.Get(1);

            Assert.IsNotNull(addedOrder);



        }
    }
}
