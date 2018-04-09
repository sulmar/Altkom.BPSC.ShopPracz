namespace Altkom.BPSC.ShopPracz.Models
{
    public class Customer : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public bool IsDeleted { get; set; }
    }


}
