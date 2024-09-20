using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectX.Common.Auth;
using ProjectX.Storage.Repositories.User;

namespace ProjectX.Commands.Auth
{
    public class LoginCommand : IRequest<TokenResponseDto>
    {
        public LoginRequest AccountRequest { get; set; }

        public LoginCommand(LoginRequest accountRequest)
        {
            AccountRequest = accountRequest;
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, TokenResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<TokenResponseDto> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            UserLoginDto dbUserLoginDto = await _userRepository.GetUserByEmailAsync(command.AccountRequest.Email);

            if (BCrypt.Net.BCrypt.Verify(command.AccountRequest.Password, dbUserLoginDto.UserPassword))
            {
                string token = CreateToken(dbUserLoginDto);

                return new TokenResponseDto
                {
                    Token = token,
                    CompanyUid = dbUserLoginDto.CompanyUid
                };
            }

            throw new Exception("Invalid password");
        }

        private string CreateToken(UserLoginDto user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.UserEmail)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var issuer = _configuration.GetSection("Jwt:Issuer").Value;
            var audience = _configuration.GetSection("Jwt:Audience").Value;

            var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
