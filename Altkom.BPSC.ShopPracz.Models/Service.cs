namespace Altkom.BPSC.ShopPracz.Models
{
    public class Service : Article
    {
        public Service(string name, decimal unitPrice) 
            : base(name, unitPrice)
        {
        }

        public Service()
            : this("Brak nazwy", 0)
        {

        }
    }


}
