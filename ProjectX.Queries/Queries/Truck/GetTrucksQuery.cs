using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Contracts.Responses.Truck;
using ProjectX.Queries.Database.Context;

namespace ProjectX.Queries.Queries.Truck
{
    public class GetTrucksQuery : IRequest<IReadOnlyList<TruckDto>>
    {
        public Guid CompanyUid { get; set; }

        public GetTrucksQuery(Guid companyUid)
        {
            CompanyUid = companyUid;
        }
    }

    public class GetTrucksQueryHandler : RepositoryBase, IRequestHandler<GetTrucksQuery, IReadOnlyList<TruckDto>>
    {
        public GetTrucksQueryHandler(IProjectXReadOnlyContext projectReadOnlyContext) : base(projectReadOnlyContext) { }

        public async Task<IReadOnlyList<TruckDto>> Handle(GetTrucksQuery request, CancellationToken cancellationToken)
        {
            return await (from truck in _projectXReadOnlyContext.Set<Entities.Truck.Truck>()                          
                          join company in _projectXReadOnlyContext.Set<Entities.Company.Company>().Where(x => x.Uid == request.CompanyUid) 
                              on truck.CompanyId equals company.Id
                          select new TruckDto
                          {
                              CombinationNumber = truck.CombinationNumber,
                              Vin = truck.Vin,
                              ManufacturedOn = truck.ManufacturedOn,
                              Registration = truck.Registration,
                              RegistrationExpiryDate = truck.RegistrationExpiryDate
                          })
                          .OrderBy(x => x.Registration)
                          .ToArrayAsync();
        }
    }
}
