using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomer();
        List<Customer> GetCustomerByUser(int userId);
        List<Customer> GetCustomerByFilter(Domain.Filter filter);
        List<City> GetAllCities();
        List<Gender> GetAllGenders();
        List<Classification> GetAllClassifications();
        List<UserSys> GetAllSellers();
        List<Region> GetAllRegions();
    }
}