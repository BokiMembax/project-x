using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Contracts.Responses.User;
using ProjectX.Queries.Database.Context;

namespace ProjectX.Queries.Queries.User
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public Guid UserUid { get; set; }

        public GetUserQuery(Guid userUid)
        {
            UserUid = userUid;
        }
    }

    public class GetUserQueryHandler : RepositoryBase, IRequestHandler<GetUserQuery, UserDto>
    {
        public GetUserQueryHandler(IProjectXReadOnlyContext projectReadOnlyContext) : base(projectReadOnlyContext) { }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = await _projectXReadOnlyContext.Set<Entities.User.User>()
                                                                           .Where(x => x.Uid == request.UserUid)
                                                                           .Select(x => new UserDto
                                                                           {
                                                                               Uid = x.Uid,
                                                                               Embg = x.Embg,
                                                                               FirstName = x.FirstName,
                                                                               LastName = x.LastName,
                                                                               Email = x.Email,
                                                                               PhoneNumber = x.PhoneNumber
                                                                           })
                                                                           .SingleOrDefaultAsync();

            if (response != null)
            {
                return response;
            }

            return new UserDto { };                       
        }
    }
}
