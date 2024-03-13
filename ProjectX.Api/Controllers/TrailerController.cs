using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Commands.Trailer;
using ProjectX.Common.Trailer;
using ProjectX.Queries.Queries.Trailer;

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

        [HttpGet("{trailerUid}")]
        public async Task<Queries.Contracts.Responses.Trailer.TrailerDto> GetTruck([FromRoute] Guid companyUid, [FromRoute] Guid trailerUid)
        {
            return await _sender.Send(new GetTrailerQuery(companyUid, trailerUid));
        }

        [HttpGet]
        public async Task<IEnumerable<Queries.Contracts.Responses.Trailer.TrailerDto>> GetTrailers ([FromRoute] Guid companyUid)
        {
            return await _sender.Send(new GetTrailersQuery(companyUid));
        }

        [HttpPost]
        public async Task AddTrailer([FromRoute] Guid companyUid, [FromBody] InsertTrailerRequest trailerRequest)
        {
            await _sender.Send(new AddTrailerCommand(companyUid, trailerRequest));
        }
    }
}
