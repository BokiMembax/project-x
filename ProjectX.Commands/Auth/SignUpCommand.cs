﻿using MediatR;
using ProjectX.Common.Auth;
using ProjectX.Storage.Repositories.Company;
using ProjectX.Storage.Repositories.User;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.Auth
{
    public class SignUpCommand : IRequest<string>
    {
        public SignUpRequest AccountRequest { get; set; }

        public SignUpCommand(SignUpRequest accountRequest)
        {
            AccountRequest = accountRequest;
        }
    }

    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public SignUpCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(SignUpCommand command, CancellationToken cancellationToken)
        {
            var companyExists = await _companyRepository.DoesCompanyExistAsync(command.AccountRequest.Embs, command.AccountRequest.CompanyEmail);

            if (companyExists)
            {
                throw new Exception($"Company exists.");
            }

            var newCompany = new Storage.Entities.Company.Company
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                Embs = command.AccountRequest.Embs,
                Name = command.AccountRequest.Name,
                Address = command.AccountRequest.Address,
                Email = command.AccountRequest.CompanyEmail,
                PhoneNumber = command.AccountRequest.CompanyPhoneNumber
            };            

            var userExists = await _userRepository.DoesUserExistAsync(command.AccountRequest.Embg, command.AccountRequest.UserEmail, command.AccountRequest.UserPhoneNumber);

            if (userExists)
            {
                throw new Exception($"User exists.");                
            }

            var newUser = new Storage.Entities.User.User
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                Embg = command.AccountRequest.Embg,
                FirstName = command.AccountRequest.FirstName,
                LastName = command.AccountRequest.LastName,
                Email = command.AccountRequest.UserEmail,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.AccountRequest.Password),
                PhoneNumber = command.AccountRequest.UserPhoneNumber,
                //DateOfEmployment = command.AccountRequest.DateOfEmployment,
                //DriversCertificateSerialNumber = command.AccountRequest.DriversCertificateSerialNumber,
                //DriversCertificateIssueDate = command.AccountRequest.DriversCertificateIssueDate,
                //DriversCertificateExpiryDate = command.AccountRequest.DriversCertificateExpiryDate,
                //DrivingLicenseSerialNumber = command.AccountRequest.DrivingLicenseSerialNumber,
                //DrivingLicenseIssueDate = command.AccountRequest.DrivingLicenseIssueDate,
                //DrivingLicenseExpiryDate = command.AccountRequest.DrivingLicenseExpiryDate,
                //PassportSerialNumber = command.AccountRequest.PassportSerialNumber,
                //PassportIssueDate = command.AccountRequest.PassportIssueDate,
                //PassportExpiryDate = command.AccountRequest.PassportExpiryDate,
                //IdentityCardSerialNumber = command.AccountRequest.IdentityCardSerialNumber,
                //IdentityCardIssueDate = command.AccountRequest.IdentityCardIssueDate,
                //IdentityCardExpiryDate = command.AccountRequest.IdentityCardExpiryDate,
                Company = newCompany
            };

            newCompany.Users.Add(newUser);

            await _companyRepository.InsertCompanyAsync(newCompany);

            await _unitOfWork.SaveChangesAsync();

            return "Account added.";
        }
    }
}
