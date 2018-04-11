using Altkom.BPSC.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.BPSC.ShopPracz.MockServices
{
    public class ArticleFactory
    {
        public static Article Create(bool isProduct)
        {
            if (isProduct)
            {
                return new Product();
            }
            else
            {
                return new Service();
            }
        }

        public static Article Create(string classname)
        {
            string fullclassname = $"Altkom.BPSC.ShopPracz.Models.{classname}";

            Type type = Type.GetType(fullclassname);

            Article article = (Article) Activator.CreateInstance(type);

            return article;
        }

        public static Article Create<T>(string classname)
            where T : Article, new()
        {
            return new T();
        }
    }
}
