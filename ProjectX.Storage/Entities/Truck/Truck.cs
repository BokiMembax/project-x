using ProjectX.Storage.Entities.CemtCertificate;
using ProjectX.Storage.Entities.CmrCertificate;
using ProjectX.Storage.Entities.Common;
using ProjectX.Storage.Entities.GreenCardCertificate;

namespace ProjectX.Storage.Entities.Truck
{
    public class Truck : BaseEntity
    {
        /// <summary>
        /// Combination number entered by the user used for creating combination of truck, trailer and driver
        /// </summary>
        public string CombinationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle identification number (chassis number)
        /// </summary>
        public string Vin { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle manufacturing date
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
        /// Green Class Certificate FK
        /// </summary>
        public int? GreenClassCertificateId { get; set; }

        public virtual GreenClassCertificate.TruckGreenClassCertificate? GreenClassCertificate { get; set; }

        /// <summary>
        /// List of CEMT Certificates
        /// </summary>
        public virtual ICollection<TruckCemtCertificate> CemtCertificates { get; set; } = new List<TruckCemtCertificate>();

        /// <summary>
        /// List of CMR Certificates
        /// </summary>
        public virtual ICollection<TruckCmrCertificate> CmrCertificates { get; set; } = new List<TruckCmrCertificate>();

        /// <summary>
        /// List of tachographs
        /// </summary>
        public virtual ICollection<Tachograph.Tachograph> Tachographs { get; set; } = new List<Tachograph.Tachograph>();

        /// <summary>
        /// List of Green Card Certificates
        /// </summary>
        public virtual ICollection<TruckGreenCardCertificate> GreenCardCertificates { get; set; } = new List<TruckGreenCardCertificate>();

        /// <summary>
        /// List of users
        /// </summary>
        public virtual ICollection<User.User> Users { get; set; } = new List<User.User>();
    }
}
