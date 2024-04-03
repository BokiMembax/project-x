using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Contracts.Responses.Truck;
using ProjectX.Queries.Database.Context;

namespace ProjectX.Queries.Queries.Truck
{
    public class GetTruckQuery : IRequest<TruckDto>
    {
        public Guid CompanyUid { get; set; }

        public Guid TruckUid { get; set; }

        public GetTruckQuery(Guid companyUid, Guid truckUid)
        {
            CompanyUid = companyUid;
            TruckUid = truckUid;            
        }
    }

    public class GetTruckQueryHandler : RepositoryBase, IRequestHandler<GetTruckQuery, TruckDto>
    {
        public GetTruckQueryHandler(IProjectXReadOnlyContext projectReadOnlyContext) : base(projectReadOnlyContext) { }
        
        public async Task<TruckDto> Handle(GetTruckQuery request, CancellationToken cancellationToken)
        {
            var response = await (from dbCompany in _projectXReadOnlyContext.Set<Entities.Company.Company>().Where(x => x.Uid == request.CompanyUid)
                                  join dbTruck in _projectXReadOnlyContext.Set<Entities.Truck.Truck>().Where(x => x.Uid == request.TruckUid)
                                       on dbCompany.Id equals dbTruck.CompanyId
                                  select new TruckDto
                                  {
                                      CombinationNumber = dbTruck.CombinationNumber,
                                      Vin = dbTruck.Vin,
                                      ManufacturedOn = dbTruck.ManufacturedOn,
                                      Registration = dbTruck.Registration,
                                      RegistrationExpiryDate = dbTruck.RegistrationExpiryDate
                                  }).SingleOrDefaultAsync();

            if (response != null)
            {
                return response;
            }
            return new TruckDto { };
        }
    }
}
