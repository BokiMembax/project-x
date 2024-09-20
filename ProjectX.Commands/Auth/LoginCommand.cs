using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectX.Common.Auth;
using ProjectX.Storage.Repositories.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectX.Commands.Auth
{
    public class LoginCommand : IRequest<TokenResponseDto>
    {
        public LoginRequest AccountRequest { get; set; }

        public LoginCommand(LoginRequest accountRequest)
        {
            AccountRequest = accountRequest;
        }

        asdasdasdasd
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
            var dbUser = await _userRepository.GetUserByEmailAsync(command.AccountRequest.Email);

            if (BCrypt.Net.BCrypt.Verify(command.AccountRequest.Password, dbUser.PasswordHash))
            {
                string token = CreateToken(dbUser);

                return new TokenResponseDto
                {
                    Token = token,
                    IsSuccess = true
                };

            }            

            return new TokenResponseDto
            {
                Token = null,
                IsSuccess = false
            };   
        }

        private string CreateToken(Storage.Entities.User.User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
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
