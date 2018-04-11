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

        public virtual void Add(TItem item)
        {
            int maxId = 0;

            if (items.Any())
            {
                maxId = items.Max(p => p.Id);
            }

            item.Id = ++maxId;

            items.Add(item);
        }

        public virtual TItem Get(int id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        public virtual ICollection<TItem> Get()
        {
            return items;
        }

        public virtual void Remove(int id)
        {
            TItem item = Get(id);

            items.Remove(item);
        }

        public virtual void Update(TItem item)
        {
            throw new NotImplementedException();
        }
    }
}
