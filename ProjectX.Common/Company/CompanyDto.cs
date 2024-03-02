namespace ProjectX.Common.Company
{
    public class CompanyDto
    {
        public Guid Uid { get; set; }

        public string Embs { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;        

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
    }
}
