using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.GreenCardCertificate
{
    public class TrailerGreenCardCertificate : BaseEntity
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
        /// Trailer FK
        /// </summary>
        public int TrailerId { get; set; }

        public virtual Trailer.Trailer Trailer { get; set; } = null!;
    }
}
