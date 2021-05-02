

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SearchCustomers.Domain;
using SearchCustomers.Repository.DataContext;
using SearchCustomers.Repository.Interfaces;

namespace SearchCustomers.Repository
{
    public class SearchCustomersRepository : ISearchCustomersRepository
    {
        private readonly SearchCustomersDataContext _searchCustomersContext;

        public SearchCustomersRepository(SearchCustomersDataContext searchCustomersContext)
        {
            _searchCustomersContext = searchCustomersContext;
        }
        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            IQueryable<Customer> query = _searchCustomersContext.Customers;
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
            IQueryable<Customer> query = _searchCustomersContext.Customers;
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
            IQueryable<UserSys> query = _searchCustomersContext.UserSys;
            query = query.AsNoTracking().Where(t => t.Email.ToUpper().Equals(email.ToUpper()) && t.Password.Equals(password));
            if( query.First() != null)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
