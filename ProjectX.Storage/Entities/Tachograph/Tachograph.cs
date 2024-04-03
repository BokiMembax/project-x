using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.Tachograph
{
    public class Tachograph : BaseEntity
    {
        /// <summary>
        /// Tachograph expiry date
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Tachograph expiry flag
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// Truck FK
        /// </summary>
        public int TruckId { get; set; }

        public virtual Truck.Truck Truck { get; set; } = null!;
    }
}
