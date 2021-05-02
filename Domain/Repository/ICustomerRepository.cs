using System.Collections.Generic;

namespace Domain.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer();
        List<Customer> GetCustomerByUser(int userId);
        bool ValidateUser(string email, string password);
    }
}