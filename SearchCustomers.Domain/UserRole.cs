namespace SearchCustomers.Domain
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public int UserSysId { get; set; }
        public UserSys UserSys { get; set; }

    }
}