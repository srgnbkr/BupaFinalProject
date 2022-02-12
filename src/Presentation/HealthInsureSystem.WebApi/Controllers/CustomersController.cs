using HealthInsureSystem.Business.Abstract;
using HealthInsureSystem.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthInsureSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);

        }

        [HttpGet("getById")]
        public IActionResult GeyById(int id)
        {
            var result = _customerService.GetCustomer(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();

        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();

        }
    }

}
