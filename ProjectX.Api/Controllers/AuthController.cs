using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Commands.Auth;
using ProjectX.Common.Auth;

namespace ProjectX.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ISender _sender;

        public AuthController(ILogger<AuthController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task RegisterAccount([FromBody] SignUpRequest accountRequest)
        {
            await _sender.Send(new SignUpCommand(accountRequest));
        }

        [HttpPost]
        [Route("login")]
        public async Task<TokenResponseDto> Login([FromBody] LoginRequest accountRequest)
        {
            return await _sender.Send(new LoginCommand(accountRequest));
        }
    }
}
