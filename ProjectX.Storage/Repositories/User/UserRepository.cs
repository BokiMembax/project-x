using Microsoft.EntityFrameworkCore;
using ProjectX.Common.Auth;
using ProjectX.Storage.Database.Context;

namespace ProjectX.Storage.Repositories.User
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IProjectXContext projectXContext) : base(projectXContext)
        {

        }

        public async Task<Entities.User.User> GetUserByUidAsync(Guid userUid)
        {
            var dbUser = await All<Entities.User.User>().SingleOrDefaultAsync(x => x.Uid == userUid);

            if (dbUser == null)
            {
                throw new Exception($"User with Uid {userUid} not found.");
            }

            return dbUser;
        }

        public async Task<UserLoginDto> GetUserByEmailAsync(string email)
        {
            UserLoginDto? userLoginDto = await (from dbUser in All<Entities.User.User>().Where(x => x.Email == email)
                                                join dbCompany in All<Entities.Company.Company>()
                                                   on dbUser.CompanyId equals dbCompany.Id
                                                select new UserLoginDto
                                                {
                                                    UserEmail = dbUser.Email,
                                                    UserPassword = dbUser.PasswordHash,
                                                    CompanyUid = dbCompany.Uid,
                                                }).SingleOrDefaultAsync();

            if (userLoginDto is null)
            {
                throw new Exception($"User with Email {email} not found.");
            }

            return userLoginDto;
        }

        public async Task<bool> DoesUserExistAsync(string embg, string email, string phoneNumber)
        {
            return await All<Entities.User.User>().AnyAsync(x => x.Embg == embg || x.Email == email || x.PhoneNumber == phoneNumber);
        }

        public async Task InsertUserAsync(Entities.User.User user)
        {
            await InsertAsync(user);
        }
    }
}
