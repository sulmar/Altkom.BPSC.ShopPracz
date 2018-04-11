using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.BPSC.ShopPracz.Models.SearchCriteria
{
    public abstract class PeriodSearchCriteria : Base
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    public class OrderSearchCriteria : PeriodSearchCriteria
    {
        public Customer Customer { get; set; }
        public decimal? FromAmount { get; set; }
        public decimal? ToAmount { get; set; }

    }
}
