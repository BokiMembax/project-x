namespace ProjectX.Common.CmrCertificate
{
    public class InsertTruckCmrCertificateRequest
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }
    }
}
