using Altkom.BPSC.ShopPracz.IServices;
using Altkom.BPSC.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

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
                .OrderByDescending(item => item.Name)
                .ThenBy(item => item.UnitPrice)
                .ThenBy(item => item.Id)
                .OfType<Service>()
                .ToList<Article>();

            var q2 = from item in this.items
                    where item.Name.Contains(name)
                    && item.Id > 5
                    orderby item.Name descending, item.UnitPrice, item.Id
                    select item;





            return articles;

        }

        public ICollection<Article> Get(string fieldname, object value)
        {
            var eParam = Expression.Parameter(typeof(Article), "e");

            var expression = Expression.Lambda<Func<Article, bool>>(
                Expression.GreaterThan(
                Expression.Property(eParam, fieldname),
                Expression.Constant(value)),
                eParam).Compile();

            var articles = this.items.Where(expression).ToList();

            return articles;
        }

        
         public ICollection<(string color, int qty)> GetColorQuantities()
        {
            var element = (kolor: "Green", qty: 10);

            var q = items
                .OfType<Product>()
                .GroupBy(item => item.Color)
                .Select(g => new { Color = g.Key, Products = g });

            var q2 = items
             .OfType<Product>()
             .GroupBy(item => item.Color)
             .Select(g => new { Color = g.Key, Qty = g.Count() });

            var q4 = q2.Select(p => (p.Color, p.Qty));

            var results = items
             .OfType<Product>()
             .GroupBy(item => item.Color)
             .Select(g => (Color: g.Key, Qty: g.Count()) )
             .ToList();

            return results;

        }

      
    }
}
