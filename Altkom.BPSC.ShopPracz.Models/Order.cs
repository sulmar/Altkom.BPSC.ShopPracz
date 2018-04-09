using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.BPSC.ShopPracz.Models
{
    public class Order : Base
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> Details { get; set; }

        public Order(string orderNumber, Customer customer, DateTime orderDate)
        {
            if (string.IsNullOrEmpty(orderNumber))
                throw new ArgumentNullException(nameof(orderNumber));

            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            OrderDate = orderDate;
            Status = OrderStatus.Draft;
            Details = new List<OrderDetail>();

            OrderNumber = orderNumber;
            Customer = customer;
        }

        public Order(string orderNumber, Customer customer)
            : this(orderNumber, customer, DateTime.Now)
        {
        }
    }


}
