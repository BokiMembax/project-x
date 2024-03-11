using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.GreenClassCertificate
{
    public class TruckGreenClassCertificate : BaseEntity
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }

        public int EmissionClassId { get; set; }

        public virtual EmissionClass.EmissionClass EmissionClass { get; set; } = null!;
    }
}

