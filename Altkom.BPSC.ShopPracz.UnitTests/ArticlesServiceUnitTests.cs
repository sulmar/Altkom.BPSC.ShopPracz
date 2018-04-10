using System;
using Altkom.BPSC.ShopPracz.IServices;
using Altkom.BPSC.ShopPracz.MockServices;
using Altkom.BPSC.ShopPracz.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Altkom.BPSC.ShopPracz.UnitTests
{

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

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
        public void GetArticlesTest()
        {
            string name = "Product";

            AddArticlesTest();

            var articles = articlesService.Get(name);

            Assert.IsNotNull(articles);

        }

        [TestMethod]
        public void GetDynamicTest()
        {
            // Arrange

            AddArticlesTest();

            string fieldname = "UnitPrice";
            object value = 8m;

            // Acts
            var articles = articlesService.Get(fieldname, value);
            // Asserts

            Assert.IsNotNull(articles);
        }

        [TestMethod]
        public void GroupByTest()
        {
            AddArticlesTest();

            var results = articlesService.GetColorQuantities();

            Assert.IsNotNull(results);

        }

        [TestMethod]
        public void UnionTest()
        {
            AddArticlesTest();

            var articles = articlesService.Get();

            var products = articles.OfType<Product>();

            var redProducts = products.Where(p => p.Color == "Red");

            var blueProducts = products.Where(p => p.Color == "Blue");

            var redandblueProducts = redProducts.Concat(blueProducts);

            var notBlueProducts = products.Except(blueProducts);

            var isOver100 = products.All(p => p.UnitPrice > 100);

            var hasGreenProduct = products.Any(p => p.Color == "Green");


        }
    }
}
