

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SearchCustomers.Domain;
using SearchCustomers.Repository.DataContext;
using SearchCustomers.Repository.Interfaces;

namespace SearchCustomers.Repository
{
    public class SearchCustomersRepository : Interfaces.ISearchCustomersRepository
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
            .Include(d => d.City);
            query = query.AsNoTracking().OrderBy(p => p.Name);
            return  await query.ToListAsync();
        }
    }
}
