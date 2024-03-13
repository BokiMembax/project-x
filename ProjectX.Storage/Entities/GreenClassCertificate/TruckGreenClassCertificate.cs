using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.GreenClassCertificate
{
    public class TruckGreenClassCertificate : BaseEntity
    {
        /// <summary>
        /// Certificate expiry date
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Certificate expiry flag
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// EmissionClass FK
        /// </summary>
        public int EmissionClassId { get; set; }

        public virtual EmissionClass.EmissionClass EmissionClass { get; set; } = null!;
    }
}

