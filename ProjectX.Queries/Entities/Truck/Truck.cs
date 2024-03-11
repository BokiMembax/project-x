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

        public int? GreenClassCertificateId { get; set; }

        public virtual GreenClassCertificate.GreenClassCertificate? GreenClassCertificate { get; set; }

        public virtual ICollection<CemtCertificate.TruckCemtCertificate> CemtCertificates { get; set; } = [];

        public virtual ICollection<CmrCertificate.TruckCmrCertificate> CmrCertificates { get; set; } = [];

        public virtual ICollection<Tachograph.Tachograph> Tachographs { get; set; } = [];

        public virtual ICollection<GreenCardCertificate.TruckGreenCardCertificate> GreenCardCertificates { get; set; } = [];

        public virtual ICollection<User.User> Users { get; set; } = [];
    }
}
