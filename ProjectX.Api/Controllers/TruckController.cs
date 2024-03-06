using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Commands.Truck;
using ProjectX.Common.Truck;
using ProjectX.Queries.Queries.Truck;

namespace ProjectX.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/companies/{companyUid}/trucks")]
    public class TruckController : ControllerBase
    {
        private readonly ILogger<TruckController> _logger;
        private readonly ISender _sender;

        public TruckController(ILogger<TruckController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet("{truckUid}")]
        public async Task<Queries.Contracts.Responses.Truck.TruckDto> GetUser([FromRoute] Guid truckUid)
        {
            return await _sender.Send(new GetTruckQuery(truckUid));
        }

        [HttpPost]
        public async Task AddTruck([FromBody] InsertTruckRequest truckRequest)
        {
            await _sender.Send(new AddTruckCommand(truckRequest));
        }
    }
}
