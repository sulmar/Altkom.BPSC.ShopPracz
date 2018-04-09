using Altkom.BPSC.ShopPracz.Models;
using System.Collections.Generic;

namespace Altkom.BPSC.ShopPracz.IServices
{
    public interface ICustomersService : IItemsService<Customer>
    {
        ICollection<Customer> Get(string fullname);
    }

}
