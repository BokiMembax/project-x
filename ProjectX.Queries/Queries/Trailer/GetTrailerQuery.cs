using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Contracts.Responses.Trailer;
using ProjectX.Queries.Database.Context;

namespace ProjectX.Queries.Queries.Trailer
{
    public class GetTrailerQuery : IRequest<TrailerDto>
    {
        public Guid CompanyUid { get; set; }

        public Guid TrailerUid { get; set; }

        public GetTrailerQuery(Guid companyUid, Guid trailerUid)
        {
            CompanyUid = companyUid;
            TrailerUid = trailerUid;
        }
    }

    public class GetTrailerQueryHandler : RepositoryBase, IRequestHandler<GetTrailerQuery, TrailerDto>
    {
        public GetTrailerQueryHandler(IProjectXReadOnlyContext projectReadOnlyContext) : base(projectReadOnlyContext) { }

        public async Task<TrailerDto> Handle(GetTrailerQuery request, CancellationToken cancellationToken)
        {
            var response = await (from dbCompany in _projectXReadOnlyContext.Set<Entities.Company.Company>().Where(x => x.Uid == request.CompanyUid)
                                  join dbTrailer in _projectXReadOnlyContext.Set<Entities.Trailer.Trailer>().Where(x => x.Uid == request.TrailerUid)
                                       on dbCompany.Id equals dbTrailer.CompanyId
                                  select new TrailerDto
                                  {
                                      Vin = dbTrailer.Vin,
                                      ManufacturedOn = dbTrailer.ManufacturedOn,
                                      Registration = dbTrailer.Registration,
                                      RegistrationExpiryDate = dbTrailer.RegistrationExpiryDate
                                  }).SingleOrDefaultAsync();

            if (response != null)
            {
                return response;
            }
            return new TrailerDto { };
        }
    }
}
