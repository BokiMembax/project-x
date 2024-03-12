using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.Company
{
    public class Company : BaseEntity
    {
        /// <summary>
        /// Unique company identification/registration number
        /// </summary>
        public string Embs { get; set; } = string.Empty;

        /// <summary>
        /// Company name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Company address
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Company email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Company phone number
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// List of users
        /// </summary>
        public virtual ICollection<User.User> Users { get; set; } = new List<User.User>();

        /// <summary>
        /// List of trucks
        /// </summary>
        public virtual ICollection<Truck.Truck> Trucks { get; set; } = new List<Truck.Truck>();

        /// <summary>
        /// List of trailers
        /// </summary>
        public virtual ICollection<Trailer.Trailer> Trailers { get; set; } = new List<Trailer.Trailer>();
    }
}
