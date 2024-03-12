using ProjectX.Queries.Entities.CemtCertificate;
using ProjectX.Queries.Entities.CmrCertificate;
using ProjectX.Queries.Entities.Common;
using ProjectX.Queries.Entities.GreenCardCertificate;

namespace ProjectX.Queries.Entities.Truck
{
    public class Truck : BaseEntity
    {
        public string CombinationNumber { get; set; } = string.Empty;

        public string Vin { get; set; } = string.Empty;

        public DateTime ManufacturedOn { get; set; }

        public string Registration { get; set; } = string.Empty;

        public DateTime? RegistrationExpiryDate { get; set; }

        public int CompanyId { get; set; }

        public int? GreenClassCertificateId { get; set; }

        public virtual Company.Company Company { get; set; } = null!;

        public virtual GreenClassCertificate.TruckGreenClassCertificate? GreenClassCertificate { get; set; }

        public virtual ICollection<TruckCemtCertificate> CemtCertificates { get; set; } = new List<TruckCemtCertificate>();

        public virtual ICollection<TruckCmrCertificate> CmrCertificates { get; set; } = new List<TruckCmrCertificate>();

        public virtual ICollection<Tachograph.Tachograph> Tachographs { get; set; } = new List<Tachograph.Tachograph>();

        public virtual ICollection<TruckGreenCardCertificate> GreenCardCertificates { get; set; } = new List<TruckGreenCardCertificate>();

        public virtual ICollection<User.User> Users { get; set; } = new List<User.User>();
    }
}
