using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.GreenCardCertificate
{
    public class TruckGreenCardCertificate : BaseEntity
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
        /// Truck FK
        /// </summary>
        public int TruckId { get; set; }

        public virtual Truck.Truck Truck { get; set; } = null!;
    }
}
