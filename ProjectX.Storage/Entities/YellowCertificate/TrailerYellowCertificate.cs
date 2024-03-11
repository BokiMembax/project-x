using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.YellowCertificate
{
    public class TrailerYellowCertificate : BaseEntity
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }

        public int TrailerId { get; set; }

        public virtual Trailer.Trailer Trailer { get; set; } = null!;
    }
}
