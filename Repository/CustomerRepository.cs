

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository.DataContext;
using Repository.Interfaces;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDataContext _customerContext;

        public CustomerRepository(CustomerDataContext customerContext)
        {
            _customerContext = customerContext;
        }
        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            IQueryable<Customer> query = _customerContext.Customers;
            query = query
             .Include(d => d.Gender)
             .Include(d => d.Region)
             .Include(d => d.Classification)
             .Include(d => d.User).ThenInclude(p => p.UserRole)
             .Include(d => d.City).ThenInclude(p => p.Region);

            query = query.AsNoTracking().OrderBy(p => p.Name);
            return  await query.ToListAsync();
        }

        public async Task<List<Customer>> GetCustomerByUser(int userId)
        {
            IQueryable<Customer> query = _customerContext.Customers;
            query = query
             .Include(d => d.Gender)
             .Include(d => d.Region)
             .Include(d => d.Classification)
             .Include(d => d.User).ThenInclude(p => p.UserRole)
             .Include(d => d.City).ThenInclude(p => p.Region);

            query = query.AsNoTracking().Where(p => p.UserId == userId).OrderBy(p => p.Name);            
            return  await query.ToListAsync();
        }

        public bool ValidateUser(string email, string password)
        {
            bool isValid = false;
            IQueryable<UserSys> query = _customerContext.UserSys;
            query = query.AsNoTracking().Where(t => t.Email.ToUpper().Equals(email.ToUpper()) && t.Password.Equals(password));
            if( query.First() != null)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
