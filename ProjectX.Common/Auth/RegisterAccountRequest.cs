using System.ComponentModel.DataAnnotations;

namespace ProjectX.Common.Auth
{
    public class RegisterAccountRequest
    {
        public string Embs { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        
        public string CompanyEmail { get; set; } = string.Empty;

        public string CompanyPhoneNumber { get; set; } = string.Empty;

        public string Embg { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string UserEmail { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string UserPhoneNumber { get; set; } = string.Empty;
    }
}
