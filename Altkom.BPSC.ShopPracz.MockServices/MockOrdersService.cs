using Altkom.BPSC.ShopPracz.IServices;
using Altkom.BPSC.ShopPracz.Models;
using Altkom.BPSC.ShopPracz.Models.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.BPSC.ShopPracz.MockServices
{

    public class MockOrdersService : IOrdersService
    {
        private ICollection<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            int maxId = 0;

            if (orders.Any())
            { 
                maxId = orders.Max(p => p.Id);
            }

            order.Id = ++maxId;
            orders.Add(order);
        }

        public Order Get(int id)
        {
            return orders.FirstOrDefault(order => order.Id == id);
        }

        public ICollection<Order> Get()
        {
            return orders;
        }

        public void Remove(int id)
        {
            Order order = Get(id);

            orders.Remove(order);
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> Get(OrderSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
