using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.DataContext;

namespace Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly CustomerDataContext _customerContext;

        public AuthenticationRepository(CustomerDataContext customerContext)
        {
            _customerContext = customerContext;
        }
        public UserSys ValidateUser(string email, string password)
        {            
            IQueryable <UserSys> query = _customerContext.UserSys;
            query = query.AsNoTracking().Include(q => q.UserRole);
            foreach (var item in query)
            {
                if(item.Email.ToLower().Equals(email.ToLower()) && GenerateMd5(item.Password).Equals(password))
                {
                    UserSys objRet = item.Clone();
                    objRet.Password = GenerateMd5(objRet.Password);
                    return objRet;
                }
            }
            return null;
        }

        public UserSys GetUserByLogin(string login)
        {
            IQueryable<UserSys> query = _customerContext.UserSys;
            query = query.AsNoTracking().Where(c => c.Login.ToLower().Equals(login.ToLower()));
            query = query.Include(q => q.UserRole);
            if (query != null && query.First() != null)
            {
                UserSys retObj = query.First().Clone();
                retObj.Password = GenerateMd5(retObj.Password);
                return retObj;
            }

            return query.FirstOrDefault();
        }

        private static string GenerateMd5(string input)
        {
            MD5 md5Hash = MD5.Create();            
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));            
            StringBuilder sBuilder = new StringBuilder();
            //format tostring
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}