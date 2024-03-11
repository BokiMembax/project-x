namespace ProjectX.Common.Tachograph
{
    public class InsertTachographRequest
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }
    }
}
