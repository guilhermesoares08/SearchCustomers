using System;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer();
        List<Customer> GetCustomerByUser(int userId);
        List<Customer> GetCustomerByFilter(Filter filter);
    }
}