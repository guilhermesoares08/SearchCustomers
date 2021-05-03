using AutoMapper;
using Domain.Interfaces;
using Domain.Repository;

namespace Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _repo;   

        public AuthenticationService(IAuthenticationRepository repo)
        {
            _repo = repo;
        }     
        
        public UserSys ValidateUser(string email, string password)
        {
            return _repo.ValidateUser(email, password);
        }
    }
}