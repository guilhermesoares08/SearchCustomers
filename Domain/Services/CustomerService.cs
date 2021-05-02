

using System;
using System.Collections.Generic;
using AutoMapper;
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

        public List<Customer> GetAllCustomer()
        {
            return _repo.GetAllCustomer();
        }

        public List<Customer> GetCustomerByUser(int userId)
        {
            return _repo.GetCustomerByUser(userId);
        }

        public List<Customer> GetCustomerByFilter(Filter filter)
        {
            return _repo.GetCustomerByFilter(filter);

        }
    }
}