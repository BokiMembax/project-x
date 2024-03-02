using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.User
{
    public class User : BaseEntity
    {
        public string Embg { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public int CompanyId { get; set; }

        public virtual Company.Company Company { get; set; } = null!;
    }
}
