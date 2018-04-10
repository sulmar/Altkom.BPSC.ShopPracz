namespace Altkom.BPSC.ShopPracz.Models
{
    public class Customer : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public string FullName
        //{
        //    get
        //    {
        //        return $"{FirstName} {LastName}";
        //    }
        //}

        public string FullName => $"{FirstName} {LastName}";

        public void Print(string text) => System.Console.WriteLine(text);

        public bool IsDeleted { get; set; }
    }


}
