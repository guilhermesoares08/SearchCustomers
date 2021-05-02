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
    public class CustomerController : ControllerBase
    {
        private readonly ISearchCustomersRepository _repo;
        private readonly IMapper _mapper;

        public CustomerController(ISearchCustomersRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
         
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllCustomerAsync();

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