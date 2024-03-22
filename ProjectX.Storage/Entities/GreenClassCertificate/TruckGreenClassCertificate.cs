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
        /// Emission class name
        /// </summary>
        public string EmissionClassName {  get; set; } = string.Empty;

        /// <summary>
        /// Emission class description
        /// </summary>
        public string EmissionClassDescription { get; set; } = string.Empty;
    }
}

