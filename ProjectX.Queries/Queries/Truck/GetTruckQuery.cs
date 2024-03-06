using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Contracts.Responses.Truck;
using ProjectX.Queries.Database.Context;

namespace ProjectX.Queries.Queries.Truck
{
    public class GetTruckQuery : IRequest<TruckDto>
    {
        public Guid TruckUid { get; set; }

        public GetTruckQuery(Guid truckUid)
        {
            TruckUid = truckUid;
        }
    }

    public class GetTruckQueryHandler : RepositoryBase, IRequestHandler<GetTruckQuery, TruckDto>
    {
        public GetTruckQueryHandler(IProjectXReadOnlyContext projectReadOnlyContext) : base(projectReadOnlyContext) { }

        public async Task<TruckDto> Handle(GetTruckQuery request, CancellationToken cancellationToken)
        {
            var response = await _projectXReadOnlyContext.Set<Entities.Truck.Truck>()
                                                                           .Where(x => x.Uid == request.TruckUid)
                                                                           .Select(x => new TruckDto
                                                                           {
                                                                               CombinationNumber = x.CombinationNumber,
                                                                               Vin = x.Vin,
                                                                               ManufacturedOn = x.ManufacturedOn,
                                                                               Registration = x.Registration,
                                                                               RegistrationExpiryDate = x.RegistrationExpiryDate
                                                                           })
                                                                           .SingleOrDefaultAsync();

            if (response != null)
            {
                return response;
            }

            return new TruckDto { };
        }
    }
}
