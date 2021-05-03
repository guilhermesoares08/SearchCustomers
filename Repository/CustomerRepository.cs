

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository.DataContext;
using Domain.Repository;
using System;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDataContext _customerContext;    

        public CustomerRepository(CustomerDataContext customerContext)
        {
            _customerContext = customerContext;            
        }
        public List<Customer> GetAllCustomers()
        {
            IQueryable<Customer> query = _customerContext.Customers;
            query = query
             .Include(d => d.Gender)
             .Include(d => d.Region)
             .Include(d => d.Classification)
             .Include(d => d.User).ThenInclude(p => p.UserRole)
             .Include(d => d.City).ThenInclude(p => p.Region);

            query = query.AsNoTracking().OrderBy(p => p.Name);
            return query.ToList();
        }

        public List<Customer> GetCustomerByUser(int userId)
        {
            IQueryable<Customer> query = _customerContext.Customers;
            query = query
             .Include(d => d.Gender)
             .Include(d => d.Region)
             .Include(d => d.Classification)
             .Include(d => d.User).ThenInclude(p => p.UserRole)
             .Include(d => d.City).ThenInclude(p => p.Region);

            query = query.AsNoTracking().Where(p => p.UserId == userId).OrderBy(p => p.Name);
            return query.ToList();
        }

        public List<Customer> GetCustomerByFilter(Filter filter)
        {
            string text = string.Empty;
            IQueryable<Customer> query = _customerContext.Customers;
            query = query
             .Include(d => d.Gender)
             .Include(d => d.Region)
             .Include(d => d.Classification)
             .Include(d => d.User).ThenInclude(p => p.UserRole)
             .Include(d => d.City).ThenInclude(p => p.Region);

            if (filter.CityId.HasValue)
            {
                query = query.AsNoTracking().Where(p => p.CityId.Equals(filter.CityId));
            }
            if (filter.ClassificationId.HasValue)
            {
                query = query.AsNoTracking().Where(p => p.ClassificationId.Equals(filter.ClassificationId));
            }
            if (filter.GenderId.HasValue)
            {
                query = query.AsNoTracking().Where(p => p.GenderId.Equals(filter.GenderId));
            }
            if (filter.SellerId.HasValue)
            {
                query = query.AsNoTracking().Where(p => p.UserId.Equals(filter.SellerId));
            }
            if (filter.RegionId.HasValue)
            {
                query = query.AsNoTracking().Where(p => p.RegionId.Equals(filter.RegionId));
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                text = filter.Name.ToLower();
                query = query.AsNoTracking().Where(p => p.Name.ToLower().Contains(text));
            }
            if (filter.StartDate.HasValue)
            {
                query = query.AsNoTracking().Where(p => p.LastPurchase >= filter.StartDate);
            }
            if (filter.EndDate.HasValue)
            {
                query = query.AsNoTracking().Where(p => p.LastPurchase <= filter.EndDate);
            }
            if (filter.UserId.HasValue && GetUserSysById(filter.UserId.Value) != null && !GetUserSysById(filter.UserId.Value).UserRole.IsAdmin)
            {
                query = query.AsNoTracking().Where(p => p.UserId == filter.UserId);
            }
            query = query.AsNoTracking().OrderBy(p => p.Name);
            return query.ToList();
        }

        public List<City> GetAllCities()
        {
            IQueryable<City> query = _customerContext.Cities;
            query = query
             .Include(d => d.Region);

            query = query.AsNoTracking().OrderBy(p => p.Name);
            return query.ToList();
        }

        public List<Gender> GetAllGenders()
        {
            IQueryable<Gender> query = _customerContext.Genders;

            query = query.AsNoTracking().OrderBy(p => p.Name);
            return query.ToList();
        }

        public List<Classification> GetAllClassifications()
        {
            IQueryable<Classification> query = _customerContext.Classifications;

            query = query.AsNoTracking().OrderBy(p => p.Name);
            return query.ToList();
        }

        public List<UserSys> GetAllUsersSys()
        {
            IQueryable<UserSys> query = _customerContext.UserSys;
            query = query.Include(o => o.UserRole);
            query = query.AsNoTracking().OrderBy(p => p.Login);
            return query.ToList();
        }

        public List<Region> GetAllRegions()
        {
            IQueryable<Region> query = _customerContext.Regions;
            query = query.AsNoTracking().OrderBy(p => p.Name);
            return query.ToList();
        }
        public UserRole GetUserRoleById(int id)
        {
            IQueryable<UserRole> query = _customerContext.UserRoles;
            query = query.AsNoTracking().Where(c => c.Id == id);
            return query.FirstOrDefault();
        }

        private UserSys GetUserSysById(int id)
        {
            IQueryable<UserSys> query = _customerContext.UserSys;
            query = query.Include(q => q.UserRole);
            query = query.AsNoTracking().Where(c => c.Id == id);            
            return query.FirstOrDefault();
        }
    }
}
