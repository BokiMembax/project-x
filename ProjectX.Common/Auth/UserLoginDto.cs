namespace ProjectX.Common.Auth
{
    public class UserLoginDto
    {
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public Guid CompanyUid { get; set; }
    }
}
