using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Api.Controllers
{
    [ApiController]
    [Route("api/companies/{companyUid}/trucks/{trailerUid}/certificates")]
    public class TrailerCertificateController : ControllerBase
    {
        private readonly ILogger<TrailerCertificateController> _logger;
        private readonly ISender _sender;

        public TrailerCertificateController(ILogger<TrailerCertificateController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

    }
}
