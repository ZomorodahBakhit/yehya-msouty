using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using University.API;
using University.Core.Dtos;
using University.Core.Forms;
using University.Core.Services;

namespace University.Controllers
{
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _ser;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService ser, ILogger<AuthController> logger)
        {
            _ser = ser;
            _logger = logger;
        }

 
        [HttpPost("register")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ApiResponse Register([FromBody] RegisterForm form)
        {
            _logger.LogInformation("POST /api/auth/register called");

            var result = _ser.RegisterAsync(form).Result;

            return new ApiResponse(result);
        }

     
        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ApiResponse Login([FromBody] LoginForm form)
        {
            _logger.LogInformation("POST /api/auth/login called");

            var result = _ser.LoginAsync(form).Result;

            return new ApiResponse(result);
        }
    }
}