namespace Domain
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public UserRole Clone()
        {
            UserRole obj = new UserRole();
            obj.Id = this.Id;
            obj.Name = this.Name;
            obj.IsAdmin = this.IsAdmin;
            return obj;
        }
    }
}