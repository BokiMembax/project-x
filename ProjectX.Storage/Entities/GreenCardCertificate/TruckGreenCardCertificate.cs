using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.GreenCardCertificate
{
    public class TruckGreenCardCertificate : BaseEntity
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }

        public int TruckId { get; set; }

        public virtual Truck.Truck Truck { get; set; } = null!;
    }
}
