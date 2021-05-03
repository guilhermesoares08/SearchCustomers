using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Domain.Interfaces;
using Domain;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {        
        private readonly IAuthenticationService _service;
        private readonly IMapper _mapper;       

        public AuthenticationController(IAuthenticationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;           
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLoginDto userLogin)
        {
            try
            {                
                UserSys usr = _service.ValidateUser(userLogin.Email, userLogin.Password);
                var retUser = _mapper.Map<UserLoginDto>(usr);
                if (retUser != null)
                {
                    return Ok(new
                    {
                        user = retUser
                    });
                }
                return Unauthorized();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }

        [HttpGet("UserByLogin/{login}")]
        [AllowAnonymous]
        public IActionResult GetUserByLogin(string login)
        {
            try
            {
                UserSys usr = _service.GetUserByLogin(login);
                var retUser = _mapper.Map<UserSysDto>(usr);               
                
                return Ok(retUser);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }
    }
}