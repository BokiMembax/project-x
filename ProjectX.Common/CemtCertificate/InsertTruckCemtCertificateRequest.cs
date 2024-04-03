namespace ProjectX.Common.CemtCertificate
{
    public class InsertTruckCemtCertificateRequest
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }
    }
}
