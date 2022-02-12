﻿using HealthInsureSystem.Business.Abstract;
using HealthInsureSystem.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthInsureSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("add")]
        public IActionResult Add(Payment payment)
        {
            var result =_paymentService.Add(payment);
            if (result.Success)
                return Ok(result);
            return BadRequest();
            
        }
    }
}
