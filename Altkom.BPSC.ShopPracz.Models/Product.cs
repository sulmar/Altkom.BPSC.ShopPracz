namespace Altkom.BPSC.ShopPracz.Models
{
    public class Product : Article
    {
        public string Color { get; set; }

        public Product(string name, decimal unitPrice, string color) 
            : base(name, unitPrice)
        {
            this.Color = color;
        }

        

    }


}
