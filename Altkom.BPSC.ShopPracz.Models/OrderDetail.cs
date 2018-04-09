namespace Altkom.BPSC.ShopPracz.Models
{
    public class OrderDetail : Base
    {
        public Article Item { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }


}
