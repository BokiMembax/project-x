using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/companies/{companyUid}/trailers")]
    public class TrailerController : ControllerBase
    {
        private readonly ILogger<TrailerController> _logger;
        private readonly ISender _sender;

        public TrailerController(ILogger<TrailerController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }


    }
}
