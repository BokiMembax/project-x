using ProjectX.Storage.Entities.CemtCertificate;
using ProjectX.Storage.Entities.Common;
using ProjectX.Storage.Entities.GreenCardCertificate;
using ProjectX.Storage.Entities.YellowCertificate;

namespace ProjectX.Storage.Entities.Trailer
{
    public class Trailer : BaseEntity
    {
        /// <summary>
        /// Vehicle identification number (chassis number)
        /// </summary>
        public string Vin { get; set; } = string.Empty;

        /// <summary>
        /// The date the vehicle was manufactured
        /// </summary>
        public DateTime ManufacturedOn { get; set; }

        /// <summary>
        /// Vehicle registration plate
        /// </summary>
        public string Registration { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle registration expiry date
        /// </summary>
        public DateTime? RegistrationExpiryDate { get; set; }

        /// <summary>
        /// Company FK
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Truck FK
        /// </summary>
        public int? TruckId { get; set; }      

        public virtual Company.Company Company { get; set; } = null!;

        public virtual Truck.Truck? Truck { get; set; }        

        /// <summary>
        /// List of CEMT Certificates
        /// </summary>
        public virtual ICollection<TrailerCemtCertificate> CemtCertificates { get; set; } = new List<TrailerCemtCertificate>();

        /// <summary>
        /// List of Green Card Certificates
        /// </summary>
        public virtual ICollection<TrailerGreenCardCertificate> GreenCardCertificates { get; set; } = new List<TrailerGreenCardCertificate>();

        /// <summary>
        /// List of Yellow Certificates
        /// </summary>
        public virtual ICollection<TrailerYellowCertificate> YellowCertificates { get; set; } = new List<TrailerYellowCertificate>();

        /// <summary>
        /// List of users
        /// </summary>
        public virtual ICollection<User.User> Users { get; set; } = new List<User.User>();
    }
}
