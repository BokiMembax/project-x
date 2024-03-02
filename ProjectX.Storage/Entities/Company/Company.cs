using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.Company
{
    public class Company : BaseEntity
    {
        public string Embs { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public virtual ICollection<User.User> Users { get; set; } = new List<User.User>();
    }
}
