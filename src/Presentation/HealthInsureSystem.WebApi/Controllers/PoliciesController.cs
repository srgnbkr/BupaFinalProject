using HealthInsureSystem.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthInsureSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var data = _policyService.GetAll();
            return Ok(data);
        }
    }
}
