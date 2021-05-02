using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
namespace Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomerAsync();
        Task<List<Customer>> GetCustomerByUser(int userId);
        bool ValidateUser(string email, string password);
    }
}