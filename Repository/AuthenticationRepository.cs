using System.Linq;
using Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.DataContext;

namespace Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly CustomerDataContext _customerContext;

        public AuthenticationRepository(CustomerDataContext customerContext)
        {
            _customerContext = customerContext;
        }
        public UserSys ValidateUser(string email, string password)
        {            
            IQueryable<UserSys> query = _customerContext.UserSys;
            query = query.AsNoTracking().Where(t => t.Email.ToUpper().Equals(email.ToUpper()) && t.Password.Equals(password));
            return query.FirstOrDefault();
        }
    }
}