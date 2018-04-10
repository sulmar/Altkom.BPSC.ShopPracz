using System;
using Altkom.BPSC.ShopPracz.IServices;
using Altkom.BPSC.ShopPracz.MockServices;
using Altkom.BPSC.ShopPracz.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Altkom.BPSC.ShopPracz.UnitTests
{
    [TestClass]
    public class ArticlesServiceUnitTests
    {
        IArticlesService articlesService;

        [TestInitialize]
        public void Init()
        {
            articlesService = new MockArticlesService();
        }

        [TestMethod]
        public void AddArticlesTest()
        {
            // Acts
            
            // products
            for (int i = 1; i <= 10; i++)
            {
                var product = new Product($"Product {i}", 10.00m, "Blue");
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

            Assert.IsTrue(products.Count>=10);


            
            
        }

        [TestMethod]
        public void GetArticlesTest()
        {
            string name = "Product";

            AddArticlesTest();

            var articles = articlesService.Get(name);

            Assert.IsNotNull(articles);


        }
    }
}
