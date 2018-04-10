namespace Altkom.BPSC.ShopPracz.Models
{
    public abstract class Article : Base
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }


        public Article(string name, decimal unitPrice)
        {
            this.Name = name;
            this.UnitPrice = unitPrice;
        }
        
    }


}
