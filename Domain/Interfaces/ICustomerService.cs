using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomer();
        List<Customer> GetCustomerByUser(int userId);
        List<Customer> GetCustomerByFilter(Domain.Filter filter);
    }
}