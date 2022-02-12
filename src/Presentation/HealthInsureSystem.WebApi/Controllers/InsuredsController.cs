using HealthInsureSystem.Business.Abstract;
using HealthInsureSystem.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthInsureSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredsController : ControllerBase
    {
        private readonly IInsuredService _insuredService;

        public InsuredsController(IInsuredService insuredService)
        {
            _insuredService = insuredService;
        }

        [HttpPost("add")]
        public IActionResult Add(Insured insured)
        {
            var result = _insuredService.Add(insured);
            if (result.Success)
                return Ok(result);
            return BadRequest();

        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _insuredService.GetInsured(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();

        }
        
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _insuredService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();

        }


        [HttpGet("getCustomerId")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _insuredService.GeyByCustomerId(customerId);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }


        [HttpGet("getInsuredDetail")]
        public IActionResult GetInsuredDetail()
        {
            var result = _insuredService.GetInsuredDetail();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
