using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.User
{
    public class User : BaseEntity
    {
        public string Embg { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime? DateOfEmployment { get; set; }

        public string DriversCertificateSerialNumber { get; set; } = string.Empty;        

        public DateTime? DriversCertificateIssueDate { get; set; }

        public DateTime? DriversCertificateExpiryDate { get; set; }

        public string DrivingLicenseSerialNumber { get; set; } = string.Empty;

        public DateTime? DrivingLicenseIssueDate { get; set; }

        public DateTime? DrivingLicenseExpiryDate { get; set; }

        public string PassportSerialNumber { get; set; } = string.Empty;

        public DateTime? PassportIssueDate { get; set; }

        public DateTime? PassportExpiryDate { get; set; }

        public string IdentityCardSerialNumber { get; set; } = string.Empty;

        public DateTime? IdentityCardIssueDate { get; set; }

        public DateTime? IdentityCardExpiryDate { get; set; }

        public int? TruckId { get; set; }

        public virtual Truck.Truck Truck { get; set; } = null!;

        public int CompanyId { get; set; }

        public virtual Company.Company Company { get; set; } = null!;
    }
}
