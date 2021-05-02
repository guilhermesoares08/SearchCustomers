

using System.Collections.Generic;
using AutoMapper;
using Domain.Interfaces;
using Domain.Repository;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
          private readonly ICustomerRepository _repo;
          private readonly IMapper _mapper;

         public CustomerService(ICustomerRepository repo, IMapper mapper)
         {
                _repo = repo;
                _mapper = mapper;
         }

         public List<Customer> GetAllCustomer()
         {
             return _repo.GetAllCustomer();
         }

         public List<Customer> GetCustomerByUser(int userId)
         {
             return _repo.GetCustomerByUser(userId);
         }
    }
}