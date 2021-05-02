using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


using System.Collections.Generic;
using WebAPI.Dtos;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Repository;
using Domain.Repository;
using Domain.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
         
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            try
            {
                var results = _service.GetAllCustomer();

                var resultMap = _mapper.Map<IEnumerable<CustomerDto>>(results);

                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }            
    }
}