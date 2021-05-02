using System;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer();
        List<Customer> GetCustomerByUser(int userId);
        List<Customer> GetCustomerByFilter(Filter filter);
        List<City> GetAllCities();
        List<Gender> GetAllGenders();
        List<Classification> GetAllClassifications();
        List<UserSys> GetAllUsersSys();
        List<Region> GetAllRegions();

    }
}