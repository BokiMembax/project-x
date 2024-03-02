namespace ProjectX.Storage.Repositories.User
{
    public interface IUserRepository
    {
        Task<Entities.User.User> GetUserByUidAsync(Guid userUid);

        Task<Entities.User.User> GetUserByEmailAsync(string email);

        Task<bool> DoesUserExistAsync(string embg, string email, string phoneNumber);

        Task InsertUserAsync(Entities.User.User user);
    }
}
