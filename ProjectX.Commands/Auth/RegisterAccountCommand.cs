﻿using MediatR;
using ProjectX.Common.Auth;
using ProjectX.Storage.Repositories.Company;
using ProjectX.Storage.Repositories.User;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.Auth
{
    public class RegisterAccountCommand : IRequest<string>
    {
        public RegisterAccountRequest AccountRequest { get; set; }

        public RegisterAccountCommand(RegisterAccountRequest accountRequest)
        {
            AccountRequest = accountRequest;
        }
    }

    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public RegisterAccountCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(RegisterAccountCommand command, CancellationToken cancellationToken)
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
                Password = command.AccountRequest.Password,
                PhoneNumber = command.AccountRequest.UserPhoneNumber,
                Company = newCompany
            };

            newCompany.Users.Add(newUser);

            await _companyRepository.InsertCompanyAsync(newCompany);

            await _unitOfWork.SaveChangesAsync();

            return "Account added.";
        }
    }
}