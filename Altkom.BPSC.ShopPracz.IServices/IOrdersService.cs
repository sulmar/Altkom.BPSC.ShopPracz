using Altkom.BPSC.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.BPSC.ShopPracz.IServices
{
    public interface IOrdersService
    {
        void Add(Order order);
        void Update(Order order);
        void Remove(int id);

        Order Get(int id);
        ICollection<Order> Get();
    }

}
