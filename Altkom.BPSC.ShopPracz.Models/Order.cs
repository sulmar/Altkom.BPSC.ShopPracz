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
        protected ICollection<OrderDetail> Details { get; set; }


        public void Add(OrderDetail orderDetail)
        {
            orderDetail.UnitPrice = orderDetail.Item.UnitPrice;
            this.Details.Add(orderDetail);
        }

        public void AddArticle(Article item, decimal qty = 1)
        {
            OrderDetail orderDetail = new OrderDetail
            {
                Item = item,
                Quantity = qty,
            };

            Add(orderDetail);
        }

        public bool IsSelectedCustomer
        {
            get
            {
                return Customer != null;
            }
        }

        //public decimal TotalAmount
        //{
        //    get
        //    {
        //        decimal totalAmount = 0;

        //        foreach (var detail in this.Details)
        //        {
        //            totalAmount += detail.Amount;
        //        }

        //        return totalAmount;
        //    }
        //}

        public decimal TotalAmount
        {
            get
            {
                return this.Details
                    .Where(bla => bla.Quantity > 0)
                    .Select(d => d.Amount)
                    .Sum();

                //return (from d in this.Details
                //        where d.Quantity > 0
                //        select d.Amount)
                //        .Sum();

            }
        }


        public decimal? DiscountAmount { get; set; }

        public bool HasDiscount
        {
            get
            {
                return DiscountAmount.HasValue && DiscountAmount.Value > 0;
            }
        }

        public decimal TotalAmountAfterDiscount
        {
            get
            {
                if (DiscountAmount.HasValue)
                    return TotalAmount - DiscountAmount.Value;
                else
                    return TotalAmount;
            }
        }

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
