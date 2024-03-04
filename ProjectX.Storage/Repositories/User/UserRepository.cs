using Microsoft.EntityFrameworkCore;
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

        public async Task<Entities.User.User> GetUserByEmailAsync(string email)
        {        
            var dbUser = await All<Entities.User.User>().SingleOrDefaultAsync(x => x.Email == email);

            if (dbUser == null)
            {
                throw new Exception($"User with Email {email} not found.");
            }

            return dbUser;
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
