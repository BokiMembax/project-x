using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Api.Controllers
{
    [ApiController]
    [Route("api/companies/{companyUid}/trucks/{truckUid}/certificates")]
    public class TruckCertificateController : ControllerBase
    {
        private readonly ILogger<TruckCertificateController> _logger;
        private readonly ISender _sender;

        public TruckCertificateController(ILogger<TruckCertificateController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

    }
}
