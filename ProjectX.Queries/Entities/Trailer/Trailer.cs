using ProjectX.Queries.Entities.CemtCertificate;
using ProjectX.Queries.Entities.Common;
using ProjectX.Queries.Entities.GreenCardCertificate;
using ProjectX.Queries.Entities.YellowCertificate;

namespace ProjectX.Queries.Entities.Trailer
{
    public class Trailer : BaseEntity
    {
        public string Vin { get; set; } = string.Empty;

        public DateTime ManufacturedOn { get; set; }

        public string Registration { get; set; } = string.Empty;

        public DateTime? RegistrationExpiryDate { get; set; }

        public int CompanyId { get; set; }

        public int? TruckId { get; set; }

        public virtual Company.Company Company { get; set; } = null!;

        public virtual Truck.Truck? Truck { get; set; }

        public virtual ICollection<TrailerCemtCertificate> CemtCertificates { get; set; } = new List<TrailerCemtCertificate>();

        public virtual ICollection<TrailerGreenCardCertificate> GreenCardCertificates { get; set; } = new List<TrailerGreenCardCertificate>();

        public virtual ICollection<TrailerYellowCertificate> YellowCertificates { get; set; } = new List<TrailerYellowCertificate>();

        public virtual ICollection<User.User> Users { get; set; } = new List<User.User>();
    }
}
