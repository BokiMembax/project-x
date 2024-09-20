using ProjectX.Common.Auth;

namespace ProjectX.Storage.Repositories.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// Return the user with this Uid from the database
        /// </summary>
        Task<Entities.User.User> GetUserByUidAsync(Guid userUid);

        /// <summary>
        /// Return the user with this email from the database
        /// </summary>
        Task<UserLoginDto> GetUserByEmailAsync(string email);

        /// <summary>
        /// Check if a truck with this embg or email or phone number exists in the database
        /// </summary>
        Task<bool> DoesUserExistAsync(string embg, string email, string phoneNumber);

        /// <summary>
        /// Insert this user in the database
        /// </summary>
        Task InsertUserAsync(Entities.User.User user);
    }
}
