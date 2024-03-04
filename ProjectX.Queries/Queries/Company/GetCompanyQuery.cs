using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Contracts.Responses.Company;
using ProjectX.Queries.Database.Context;

namespace ProjectX.Queries.Queries.Company
{
    public class GetCompanyQuery : IRequest<CompanyDto>
    {
        public Guid CompanyUid { get; set; }

        public GetCompanyQuery(Guid companyUid)
        {
            CompanyUid = companyUid;
        }
    }

    public class GetCompanyQueryHandler : RepositoryBase, IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        public GetCompanyQueryHandler(IProjectXReadOnlyContext projectReadOnlyContext) : base(projectReadOnlyContext) { }

        public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {           
            var response = await _projectXReadOnlyContext.Set<Entities.Company.Company>()
                                                                              .Where(x => x.Uid == request.CompanyUid)
                                                                              .Select(x => new CompanyDto
                                                                              {
                                                                                  Uid = x.Uid,
                                                                                  Embs = x.Embs,
                                                                                  Name = x.Name,
                                                                                  Address = x.Address,
                                                                                  Email = x.Email,
                                                                                  PhoneNumber = x.PhoneNumber
                                                                              })
                                                                              .SingleOrDefaultAsync();

            if (response != null)
            {
                return response;
            }

            return new CompanyDto { };
        }
    }
}
