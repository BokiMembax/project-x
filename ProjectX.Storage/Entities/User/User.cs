using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.User
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Unique Master Citizen Number
        /// </summary>
        public string Embg { get; set; } = string.Empty;

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Hashed password
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Date of employment in the respective company
        /// </summary>
        public DateTime? DateOfEmployment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DriversCertificateSerialNumber { get; set; } = string.Empty;        

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DriversCertificateIssueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DriversCertificateExpiryDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DrivingLicenseSerialNumber { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DrivingLicenseIssueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DrivingLicenseExpiryDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PassportSerialNumber { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? PassportIssueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? PassportExpiryDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IdentityCardSerialNumber { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? IdentityCardIssueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? IdentityCardExpiryDate { get; set; }

        /// <summary>
        /// Truck FK
        /// </summary>
        public int? TruckId { get; set; }

        /// <summary>
        /// Trailer FK
        /// </summary>
        public int? TrailerId { get; set; }

        /// <summary>
        /// Company FK
        /// </summary>
        public int CompanyId { get; set; }

        public virtual Truck.Truck? Truck { get; set; }

        public virtual Trailer.Trailer? Trailer { get; set; }

        public virtual Company.Company Company { get; set; } = null!;
    }
}
