﻿using MediatR;
using ProjectX.Common.User;
using ProjectX.Storage.Repositories.Company;
using ProjectX.Storage.Repositories.User;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.User
{
    public record AddUserCommand : IRequest<string>
    {
        public Guid CompanyUid { get; set; }
        public InsertUserRequest UserRequest { get; set; }      

        public AddUserCommand(Guid companyUid, InsertUserRequest userRequest)
        {
            CompanyUid = companyUid;
            UserRequest = userRequest;            
        }
    }

    public record AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var dbCompany = await _companyRepository.GetCompanyByUidAsync(command.CompanyUid);

            var userExists = await _userRepository.DoesUserExistAsync(command.UserRequest.Embg, command.UserRequest.Email, command.UserRequest.PhoneNumber);

            if (userExists)
            {
                throw new Exception($"User exists.");
            }

            var newUser = new Storage.Entities.User.User
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                Embg = command.UserRequest.Embg,
                FirstName = command.UserRequest.FirstName,
                LastName = command.UserRequest.LastName,
                Email = command.UserRequest.Email,
                PhoneNumber = command.UserRequest.PhoneNumber,
                Company = dbCompany
            };

            dbCompany.Users.Add(newUser);

            await _userRepository.InsertUserAsync(newUser);

            await _unitOfWork.SaveChangesAsync();

            return "User added.";
        }
    }
}
