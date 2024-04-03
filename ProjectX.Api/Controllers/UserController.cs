using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Commands.User;
using ProjectX.Common.User;
using ProjectX.Queries.Queries.User;

namespace ProjectX.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/companies/{companyUid}/users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ISender _sender;

        public UserController(ILogger<UserController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }
        
        [HttpGet("{userUid}")]
        public async Task<Queries.Contracts.Responses.User.UserDto> GetUser([FromRoute] Guid userUid)
        {
            return await _sender.Send(new GetUserQuery(userUid));
        }

        [HttpGet]
        public async Task<IReadOnlyList<Queries.Contracts.Responses.User.UserDto>> GetUsers([FromRoute] Guid companyUid)
        {
            return await _sender.Send(new GetUsersQuery(companyUid));
        }

        [HttpPost]
        public async Task AddUser([FromRoute] Guid companyUid, [FromBody] InsertUserRequest userRequest)
        {
            await _sender.Send(new AddUserCommand(companyUid, userRequest));
        }
    }
}
