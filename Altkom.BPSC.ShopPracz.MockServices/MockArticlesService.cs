using Altkom.BPSC.ShopPracz.IServices;
using Altkom.BPSC.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Altkom.BPSC.ShopPracz.MockServices
{

    public class MockArticlesService
        : MockItemsService<Article>, IArticlesService
    {
        public ICollection<Article> Get(string name)
        {
            //var articles = this.items
            //    .Select(item => new { item.Name, item.UnitPrice });

            int[] numbers = new int[] {  40, 65778, 6565, 6565};

            var q = numbers.Where(n => n > 100);

            var articles = this.items
                .Where(item => item.Name.Contains(name))
                .Where(item => item.Id > 5)
                .OfType<Service>()
                .ToList<Article>();


            return articles;

        }
    }
}
