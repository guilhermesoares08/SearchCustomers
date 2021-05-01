namespace SearchCustomers.Domain
{
    public class Classification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}