using Altkom.BPSC.ShopPracz.Models;
using System.Collections.Generic;

namespace Altkom.BPSC.ShopPracz.IServices
{
    public interface IItemsService<TItem>
         where TItem : Base
    {
        void Add(TItem item);
        void Update(TItem item);
        void Remove(int id);

        TItem Get(int id);
        ICollection<TItem> Get();
    }

}
