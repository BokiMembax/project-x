namespace ProjectX.Common.Trailer
{
    public class InsertTrailerRequest
    {
        public string Vin { get; set; } = string.Empty;

        public DateTime ManufacturedOn { get; set; }

        public string Registration { get; set; } = string.Empty;

        public DateTime? RegistrationExpiryDate { get; set; }
    }
}
