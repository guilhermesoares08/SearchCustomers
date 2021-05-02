using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SearchCustomers.Repository.Interfaces;

using System.Collections.Generic;
using SearchCustomers.WebAPI.Dtos;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace SearchCustomers.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISearchCustomersRepository _repo;
        private readonly IMapper _mapper;

        public AuthenticationController(ISearchCustomersRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }       

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserSysDto userLogin)
        {
            try
            {
                bool isValid = _repo.ValidateUser(userLogin.Email, userLogin.Password);
                if(isValid)
                {
                    return Ok();
                }                
                return this.StatusCode(StatusCodes.Status400BadRequest, $"The email and/or password entered is invalid. Please try again");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }        
    }
}