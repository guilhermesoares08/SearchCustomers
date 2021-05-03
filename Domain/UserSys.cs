using System.Collections.Generic;

namespace Domain
{
    public class UserSys
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        public UserSys Clone()
        {
            UserSys obj = new UserSys();
            obj.Id = this.Id;
            obj.Login = this.Login;
            obj.Email = this.Email;
            obj.Password = this.Password;
            obj.UserRoleId = this.UserRoleId;
            obj.UserRole = this.UserRole.Clone();
            return obj;
        }
    }
}
