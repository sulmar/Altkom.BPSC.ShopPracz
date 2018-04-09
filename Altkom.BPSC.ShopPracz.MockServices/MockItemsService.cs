using Altkom.BPSC.ShopPracz.IServices;
using Altkom.BPSC.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.BPSC.ShopPracz.MockServices
{
    public class MockItemsService<TItem> : IItemsService<TItem>
        where TItem : Base
    {
        protected ICollection<TItem> items = new List<TItem>();

        public void Add(TItem item)
        {
            items.Add(item);
        }

        public TItem Get(int id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        public ICollection<TItem> Get()
        {
            return items;
        }

        public void Remove(int id)
        {
            TItem item = Get(id);

            items.Remove(item);
        }

        public void Update(TItem item)
        {
            throw new NotImplementedException();
        }
    }
}
