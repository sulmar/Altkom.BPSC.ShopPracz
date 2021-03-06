﻿using System;
using System.Linq;
using Altkom.BPSC.ShopPracz.IServices;
using Altkom.BPSC.ShopPracz.MockServices;
using Altkom.BPSC.ShopPracz.Models;
using Altkom.BPSC.ShopPracz.OrderCalculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Altkom.BPSC.ShopPracz.UnitTests
{
    [TestClass]
    public class CalculatorUnitTests
    {
        private IArticlesService articlesService;

        [TestInitialize]
        public void Init()
        {
            articlesService = new MockArticlesService();
        }

        public void AddArticlesTest()
        {
            // products

            string[] colors = new string[] { "Blue", "Red", "Green" };

            for (int i = 1; i <= 10; i++)
            {
                var product = new Product($"Product {i}", 10.00m, colors[i % 3]);
                articlesService.Add(product);
            }

            // services
            for (int i = 1; i <= 3; i++)
            {
                var service = new Service($"Service {i}", 100);
                articlesService.Add(service);
            }

            // Assets

            var products = articlesService.Get();

            Assert.IsTrue(products.Count >= 10);
        }

        [TestMethod]
        public void CalculateTest()
        {
            // Arrange
            AddArticlesTest();

            Customer customer = new Customer();

            Article product1 = articlesService.Get(1);

            Order order = new Order("ZAM 1/2018", customer);
            order.OrderDate = DateTime.Parse("2018-04-13");

            order.AddArticle(product1, 2);

            var calculator = new BlackFridayCalculator();

            // Acts
            calculator.Calculate(order);

            // Assets
            Assert.AreEqual(6, order.DiscountAmount);
            Assert.IsTrue(order.HasDiscount);
        }

        [TestMethod]
        public void OrderCalculatorTest()
        {
            // Arrange
            AddArticlesTest();

            Customer customer = new Customer();

            Article product1 = articlesService.Get(1);

            Order order = new Order("ZAM 1/2018", customer);
            order.OrderDate = DateTime.Parse("2018-04-13");
            order.AddArticle(product1, 2);

            IStrategy strategy = new HappyDayOfWeekStrategy(DayOfWeek.Friday, 0.3m);

            OrderCalculator calculator = new OrderCalculator(strategy);

            // Acts
            calculator.Calculate(order);

            // Assets
            Assert.AreEqual(6, order.DiscountAmount);
            Assert.IsTrue(order.HasDiscount);
        }

        [TestMethod]
        public void OrderDiscountCalculatorTest()
        {
            // Arrange
            AddArticlesTest();

            Customer customer = new Customer();

            Article product1 = articlesService.Get(1);

            Order order = new Order("ZAM 1/2018", customer);
            order.OrderDate = DateTime.Parse("2018-04-13");
            order.AddArticle(product1, 2);

            IRuleStrategy ruleStrategy = new HappyDayRuleStrategy(DayOfWeek.Friday);

            //IRuleStrategy<Order> ruleStrategy 
            //    = new DelegateRuleStrategy<Order>(o => o.OrderDate.DayOfWeek == DayOfWeek.Friday);

            IDiscountStrategy discountStrategy = new PercentageDiscountStrategy(0.3m);

            OrderDiscountCalculator calculator = new OrderDiscountCalculator(ruleStrategy, discountStrategy);

            // Acts
            calculator.Calculate(order);

            // Assets
            Assert.AreEqual(6, order.DiscountAmount);
            Assert.IsTrue(order.HasDiscount);
        }
    }
}
