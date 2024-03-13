using ProjectX.Common.EmissionClass;

namespace ProjectX.Common.GreenClassCertificate
{
    public class InsertTruckGreenClassCertificateRequest
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }

        public InsertEmissionClassRequest EmissionClass { get; set; } = null!;
    }
}
