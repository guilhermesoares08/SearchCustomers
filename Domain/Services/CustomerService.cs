
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Repository;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public List<Customer> GetCustomerByUser(int userId)
        {
            var currentUser = this._repo.GetUserRoleById(userId);
            if(currentUser != null && currentUser.IsAdmin)
            {
                return GetAllCustomers();
            }
            return _repo.GetCustomerByUser(userId);
        }

        public List<Customer> GetCustomerByFilter(Filter filter)
        {            
            return _repo.GetCustomerByFilter(filter);
        }

        public List<City> GetAllCities()
        {
            return _repo.GetAllCities();
        }

        public List<Gender> GetAllGenders()
        {
            return _repo.GetAllGenders();
        }

        public List<Classification> GetAllClassifications()
        {
            return _repo.GetAllClassifications();
        }

        public List<UserSys> GetAllSellers()
        {
            return _repo.GetAllUsersSys();
        }

        public List<Region> GetAllRegions()
        {
            return _repo.GetAllRegions();
        }

        public UserRole GetUserRoleById(int id)
        {
            return _repo.GetUserRoleById(id);
        }

        public City GetCityById(int id)
        {
            return _repo.GetCityById(id);
        }
    }
}