using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Commands.Auth;
using ProjectX.Common.Auth;

namespace ProjectX.Api.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ISender _sender;

        public LoginController(ILogger<LoginController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost]
        public async Task<TokenResponseDto> LoginAccount([FromBody] LoginAccountRequest accountRequest)
        {            
            return await _sender.Send(new LoginAccountCommand(accountRequest));
        }
    }
}
