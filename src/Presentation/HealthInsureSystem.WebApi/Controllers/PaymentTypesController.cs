using HealthInsureSystem.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthInsureSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypesController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypesService;

        public PaymentTypesController(IPaymentTypeService paymentTypesService)
        {
            _paymentTypesService = paymentTypesService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var data = _paymentTypesService.GetAll();
            if (data.Success)
                return Ok(data);
            return BadRequest();
        }
    }
}
