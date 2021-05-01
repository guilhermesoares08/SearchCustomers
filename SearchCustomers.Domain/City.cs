using System.Collections.Generic;

namespace SearchCustomers.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int RegionId { get; set; }
        public int? CustomerId { get; set; }
        public Region Region { get; set; }
        public List<Customer> Customers { get; set; }
    }
}