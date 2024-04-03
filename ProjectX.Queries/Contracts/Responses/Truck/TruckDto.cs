namespace ProjectX.Queries.Contracts.Responses.Truck
{
    public class TruckDto
    {
        public string CombinationNumber { get; set; } = string.Empty;

        public string Vin { get; set; } = string.Empty;

        public DateTime ManufacturedOn { get; set; }

        public string Registration { get; set; } = string.Empty;

        public DateTime? RegistrationExpiryDate { get; set; }
    }
}
