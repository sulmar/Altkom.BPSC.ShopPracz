using Altkom.BPSC.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.BPSC.ShopPracz.IServices
{
    public interface IArticlesService : IItemsService<Article>
    {
        ICollection<Article> Get(string name);

        ICollection<Article> Get(string fieldname, object value);

        ICollection<(string color, int qty)> GetColorQuantities();
    }
}
