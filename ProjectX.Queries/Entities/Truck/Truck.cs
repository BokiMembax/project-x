using ProjectX.Queries.Entities.Common;

namespace ProjectX.Queries.Entities.Truck
{
    public class Truck : BaseEntity
    {
        public string CombinationNumber { get; set; } = string.Empty;

        public string Vin { get; set; } = string.Empty;

        public DateTime ManufacturedOn { get; set; }

        public string Registration { get; set; } = string.Empty;

        public DateTime? RegistrationExpiryDate { get; set; }

        public ICollection<User.User> Users { get; set; } = [];
    }
}
