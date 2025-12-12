using E_CommerceWebApi_API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace E_CommerceWebApi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        [HttpGet("unAuthorized")]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }
        [HttpGet("BadRequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest("This Is Not A Good Request");
        }
        [HttpGet("NotFound")]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }
        [HttpGet("internalError")]
        public IActionResult GetInternalError()
        {
            throw new Exception("This Is A Test Exception");
        }
        [HttpGet("validationerror")]
        public IActionResult GetValidationError(CreateProductDTO product)
        {
            return Ok();
        }
       
    }
}
