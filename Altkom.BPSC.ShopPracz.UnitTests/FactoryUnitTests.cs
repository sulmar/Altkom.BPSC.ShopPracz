using System;
using Altkom.BPSC.ShopPracz.IServices;
using Altkom.BPSC.ShopPracz.MockServices;
using Altkom.BPSC.ShopPracz.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Altkom.BPSC.ShopPracz.UnitTests
{
    [TestClass]
    public class FactoryUnitTests
    {
        [TestMethod]
        public void CreateProductTest()
        {
            // Arrange

            IArticlesService articlesService = new MockArticlesService();

            // Acts

            bool isProduct = true;

            Article article = ArticleFactory.Create(isProduct);

            //if (isProduct)
            //{
            //    article = new Product();
            //}
            //else
            //{
            //    article = new Service();
            //}

            articlesService.Add(article);
        }

        [TestMethod]
        public void CreateTest()
        {
            var article = ArticleFactory.Create("Product");

            Assert.IsNotNull(article);
        }

        [TestMethod]
        public void UnityTest()
        {
            var container = new UnityContainer();
            container.RegisterType<IArticlesService, MockArticlesService>();
            container.RegisterSingleton<ICustomersService, MockCustomersService>();


            IArticlesService articlesService = container.Resolve<IArticlesService>();

            Assert.IsNotNull(articlesService);

            var articles = articlesService.Get();

            Assert.IsNotNull(articles);

        }
    }
}
