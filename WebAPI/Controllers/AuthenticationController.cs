using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Domain.Interfaces;
using System;
using Domain;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}