
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Dtos;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Domain.Interfaces;
using Domain;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
                List<Customer> results = _service.GetAllCustomer();
                List<CustomerDto> resultMap = _mapper.Map<List<CustomerDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("getByUser/{userId}")]
        [AllowAnonymous]
        public IActionResult Get(int userId)
        {
            try
            {
                List<Customer> results = _service.GetCustomerByUser(userId);

                List<CustomerDto> resultMap = _mapper.Map<List<CustomerDto>>(results);

                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }


        [HttpPost("Filter")]
        [AllowAnonymous]
        public IActionResult Post([FromBody] FilterDto filter)
        {
            try
            {
                Filter mapFilter = _mapper.Map<Filter>(filter);
                List<Customer> results = _service.GetCustomerByFilter(mapFilter);
                var resultMap = _mapper.Map<IEnumerable<CustomerDto>>(results);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                string innerEx = ex.InnerException.Message;
                string exMessage = ex.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{exMessage + "|" + innerEx}");
            }
        }
    }
}