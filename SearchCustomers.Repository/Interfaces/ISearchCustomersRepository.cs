using System.Collections.Generic;
using System.Threading.Tasks;
using SearchCustomers.Domain;
namespace SearchCustomers.Repository.Interfaces
{
    public interface ISearchCustomersRepository
    {
        Task<List<Customer>> GetAllCustomerAsync();
    }
}