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
        public bool ValidateUser(string email, string password)
        {
            bool isValid = false;
            IQueryable<UserSys> query = _customerContext.UserSys;
            query = query.AsNoTracking().Where(t => t.Email.ToUpper().Equals(email.ToUpper()) && t.Password.Equals(password));
            if(query.First() != null)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}