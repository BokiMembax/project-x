﻿using System.ComponentModel.DataAnnotations;

namespace ProjectX.Common.Auth
{
    public class SignUpRequest
    {
        public string Embs { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        
        public string CompanyEmail { get; set; } = string.Empty;

        public string CompanyPhoneNumber { get; set; } = string.Empty;

        public string Embg { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string UserEmail { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string UserPhoneNumber { get; set; } = string.Empty;

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
    }
}
