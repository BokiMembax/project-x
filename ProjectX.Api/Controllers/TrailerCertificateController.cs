using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Commands.TrailerCertificates;
using ProjectX.Common.CemtCertificate;
using ProjectX.Common.GreenCardCertificate;
using ProjectX.Common.YellowCertificate;

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

        [HttpPost]
        [Route("cemt")]
        public async Task AddTrailerCemtCertificate([FromRoute] Guid trailerUid, InsertTrailerCemtCertificateRequest request)
        {
            await _sender.Send(new AddTrailerCemtCertificateCommand(trailerUid, request));
        }

        [HttpPost]
        [Route("greencard")]
        public async Task AddTrailerGreenCardCertificate([FromRoute] Guid trailerUid, InsertTrailerGreenCardCertificateRequest request)
        {
            await _sender.Send(new AddTrailerGreenCardCertificateCommand(trailerUid, request));
        }

        [HttpPost]
        [Route("yellow")]
        public async Task AddTrailerYellowCertificate([FromRoute] Guid trailerUid, InsertTrailerYellowCertificateRequest request)
        {
            await _sender.Send(new AddTrailerYellowCertificateCommand(trailerUid, request));
        }
    }
}
