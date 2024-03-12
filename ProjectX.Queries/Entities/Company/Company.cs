using ProjectX.Queries.Entities.Common;

namespace ProjectX.Queries.Entities.Company
{
    public class Company : BaseEntity
    {
        public string Embs { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public virtual ICollection<User.User> Users { get; set; } = new List<User.User>();

        public virtual ICollection<Truck.Truck> Trucks { get; set; } = new List<Truck.Truck>();

        public virtual ICollection<Trailer.Trailer> Trailers { get; set; } = new List<Trailer.Trailer>();
    }
}
