using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomer();
    }
}