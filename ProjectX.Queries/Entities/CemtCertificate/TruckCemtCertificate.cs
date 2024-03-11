using ProjectX.Queries.Entities.Common;

namespace ProjectX.Queries.Entities.CemtCertificate
{
    public class TruckCemtCertificate : BaseEntity
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }

        public int TruckId { get; set; }

        public virtual Truck.Truck Truck { get; set; } = null!;
    }
}
