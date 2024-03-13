using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Contracts.Responses.Trailer;
using ProjectX.Queries.Database.Context;

namespace ProjectX.Queries.Queries.Trailer
{
    public class GetTrailersQuery : IRequest<IReadOnlyList<TrailerDto>>
    {
        public Guid CompanyUid { get; set; }

        public GetTrailersQuery(Guid companyUid)
        {
            CompanyUid = companyUid;
        }
    }

    public class GetTrailersQueryHandler : RepositoryBase, IRequestHandler<GetTrailersQuery, IReadOnlyList<TrailerDto>>
    {
        public GetTrailersQueryHandler(IProjectXReadOnlyContext projectReadOnlyContext) : base(projectReadOnlyContext) { }

        public async Task<IReadOnlyList<TrailerDto>> Handle(GetTrailersQuery request, CancellationToken cancellationToken)
        {
            return await (from trailer in _projectXReadOnlyContext.Set<Entities.Trailer.Trailer>()
                          join company in _projectXReadOnlyContext.Set<Entities.Company.Company>().Where(x => x.Uid == request.CompanyUid)
                              on trailer.CompanyId equals company.Id
                          select new TrailerDto
                          {
                              Vin = trailer.Vin,
                              ManufacturedOn = trailer.ManufacturedOn,
                              Registration = trailer.Registration,
                              RegistrationExpiryDate = trailer.RegistrationExpiryDate
                          })
                          .OrderBy(x => x.Registration)
                          .ToArrayAsync();
        }
    }
}
