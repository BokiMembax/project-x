using ProjectX.Queries.Entities.Common;

namespace ProjectX.Queries.Entities.GreenClassCertificate
{
    public class TruckGreenClassCertificate : BaseEntity
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }

        public string EmissionClassName { get; set; } = string.Empty;

        public string EmissionClassDescription { get; set; } = string.Empty;
    }
}
