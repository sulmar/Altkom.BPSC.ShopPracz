using Altkom.BPSC.ShopPracz.IServices;
using Altkom.BPSC.ShopPracz.Models;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.BPSC.ShopPracz.MockServices
{
    public class MockCustomersService : MockItemsService<Customer>, ICustomersService
    {
        public ICollection<Customer> Get(string fullname)
        {
            return items.Where(customer => customer.FullName == fullname).ToList();
        }
    }
}
