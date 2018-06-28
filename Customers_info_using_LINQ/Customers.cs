
namespace ado.net___homework
{
    class Customers
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string Address{ get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }


        public Customers(string customerId, string companyName, string address, string city, string region, string country)
        {
            CustomerId = customerId;
            CompanyName = companyName;
            Address = address;
            City = city;
            Region = region;
            Country = country;

        }

        public override string ToString()
        {
            return $"CustomerId: {CustomerId}, CompanyName: {CompanyName}, Address: {Address}, City: {City}, Region: {Region}, Country: {Country} ";
        }
    }
}
