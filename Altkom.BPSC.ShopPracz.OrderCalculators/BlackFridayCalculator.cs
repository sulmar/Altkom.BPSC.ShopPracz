using Altkom.BPSC.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.BPSC.ShopPracz.OrderCalculators
{
    public class BlackFridayCalculator
    {
        public void Calculate(Order order)
        {
            if (order.OrderDate.DayOfWeek == DayOfWeek.Friday)
            {
                order.DiscountAmount = order.TotalAmount * 0.3m;
            }
            else
            {
                order.DiscountAmount = 0;
            }
        }
    }
}
