using Domain.Dtos;
using Domain.Iterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {

        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost("generate")]
        public ActionResult<List<string>> GenerateFizzBuzz(FizzBuzzRequest request)
        {
            var result = _fizzBuzzService.GenerateFizzBuzz(request);
           
            return Ok(result);
        }
    }
}
