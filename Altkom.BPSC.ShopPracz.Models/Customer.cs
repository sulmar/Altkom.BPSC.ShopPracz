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

        public Address DeliverAddress { get; set; }
        public Address WorkAddress { get; set; }

        public Location Location { get; set; }

        public bool IsDeleted { get; set; }
    }


    public class Address : Base
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
    }


}
