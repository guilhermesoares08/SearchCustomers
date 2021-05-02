using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


using System.Collections.Generic;
using WebAPI.Dtos;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Domain.Repository;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public AuthenticationController(ICustomerRepository repo, IMapper mapper)
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