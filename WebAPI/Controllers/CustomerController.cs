
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
                List<Customer> results = _service.GetAllCustomers();
                List<CustomerDto> resultMap = _mapper.Map<List<CustomerDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }


        [HttpPost("filter")]
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed{exMessage + "|" + innerEx}");
            }
        }

        [HttpGet("cities")]
        [AllowAnonymous]
        public IActionResult GetAllCities()
        {
            try
            {
                List<City> results = _service.GetAllCities();
                List<CityDto> resultMap = _mapper.Map<List<CityDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }

        [HttpGet("genders")]
        [AllowAnonymous]
        public IActionResult GetAllGenders()
        {
            try
            {
                List<Gender> results = _service.GetAllGenders();
                List<GenderDto> resultMap = _mapper.Map<List<GenderDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }

        [HttpGet("classifications")]
        [AllowAnonymous]
        public IActionResult GetAllClassifications()
        {
            try
            {
                List<Classification> results = _service.GetAllClassifications();
                List<ClassificationDto> resultMap = _mapper.Map<List<ClassificationDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }

        [HttpGet("sellers")]
        [AllowAnonymous]
        public IActionResult GetAllSellers()
        {
            try
            {
                List<UserSys> results = _service.GetAllSellers();
                List<UserSysDto> resultMap = _mapper.Map<List<UserSysDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }

        [HttpGet("regions")]
        [AllowAnonymous]
        public IActionResult GetAllRegions()
        {
            try
            {
                List<Region> results = _service.GetAllRegions();
                List<RegionDto> resultMap = _mapper.Map<List<RegionDto>>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }

        [HttpGet("cities/{id}")]
        [AllowAnonymous]
        public IActionResult GetCityById(int id)
        {
            try
            {
                City results = _service.GetCityById(id);
                CityDto resultMap = _mapper.Map<CityDto>(results);
                return Ok(resultMap);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database has failed {ex.Message}");
            }
        }
    }
}