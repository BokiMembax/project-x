namespace ProjectX.Common.GreenClassCertificate
{
    public class InsertTruckGreenClassCertificateRequest
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }

        public string EmissionClassName { get; set; } = string.Empty;

        public string EmissionClassDescription { get; set; } = string.Empty;    
    }
}
