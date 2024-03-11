using ProjectX.Queries.Entities.Common;

namespace ProjectX.Queries.Entities.GreenClassCertificate
{
    public class GreenClassCertificate : BaseEntity
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }

        public int TruckId { get; set; }

        public int EmissionClassId { get; set; }

        public virtual Truck.Truck Truck { get; set; } = null!;

        public virtual EmissionClass.EmissionClass EmissionClass { get; set; } = null!;
    }
}
