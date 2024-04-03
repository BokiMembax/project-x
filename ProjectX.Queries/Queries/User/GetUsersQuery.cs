using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Contracts.Responses.User;
using ProjectX.Queries.Database.Context;

namespace ProjectX.Queries.Queries.User
{
    public class GetUsersQuery : IRequest<IReadOnlyList<UserDto>>
    {
        public Guid CompanyUid { get; set; }

        public GetUsersQuery(Guid companyUid)
        {
            CompanyUid = companyUid;
        }
    }

    public class GetUsersQueryHandler : RepositoryBase, IRequestHandler<GetUsersQuery, IReadOnlyList<UserDto>>
    {
        public GetUsersQueryHandler(IProjectXReadOnlyContext projectReadOnlyContext) : base(projectReadOnlyContext) { }

        public async Task<IReadOnlyList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await (from user in _projectXReadOnlyContext.Set<Entities.User.User>()
                          join company in _projectXReadOnlyContext.Set<Entities.Company.Company>().Where(x => x.Uid == request.CompanyUid)
                              on user.CompanyId equals company.Id
                          select new UserDto
                          {
                              Uid = user.Uid,
                              Embg = user.Embg,
                              FirstName = user.FirstName,
                              LastName = user.LastName,
                              Email = user.Email,
                              PhoneNumber = user.PhoneNumber
                          })
                          .OrderBy(x => x.FirstName)
                          .ToArrayAsync();
        }
    }
}
