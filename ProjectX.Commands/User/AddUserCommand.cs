using MediatR;
using ProjectX.Common.User;
using ProjectX.Storage.Repositories.Company;
using ProjectX.Storage.Repositories.User;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.User
{
    public record AddUserCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public InsertUserRequest UserRequest { get; set; }      

        public AddUserCommand(Guid companyUid, InsertUserRequest userRequest)
        {
            CompanyUid = companyUid;
            UserRequest = userRequest;            
        }
    }

    public record AddUserCommandHandler : IRequestHandler<AddUserCommand>
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

        public async Task Handle(AddUserCommand command, CancellationToken cancellationToken)
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
                DateOfEmployment = command.UserRequest.DateOfEmployment,
                DriversCertificateIssueDate = command.UserRequest.DriversCertificateIssueDate,
                DriversCertificateExpiryDate = command.UserRequest.DriversCertificateExpiryDate,
                DrivingLicenseIssueDate = command.UserRequest.DrivingLicenseIssueDate,
                DrivingLicenseExpiryDate = command.UserRequest.DrivingLicenseExpiryDate,
                PassportIssueDate = command.UserRequest.PassportIssueDate,
                PassportExpiryDate = command.UserRequest.PassportExpiryDate,
                IdentityCardIssueDate = command.UserRequest.IdentityCardIssueDate,
                IdentityCardExpiryDate = command.UserRequest.IdentityCardExpiryDate,
                Company = dbCompany
            };

            if (command.UserRequest.DriversCertificateSerialNumber != null)
            {
                newUser.DriversCertificateSerialNumber = command.UserRequest.DriversCertificateSerialNumber;
            }

            if (command.UserRequest.DrivingLicenseSerialNumber != null)
            {
                newUser.DrivingLicenseSerialNumber = command.UserRequest.DrivingLicenseSerialNumber;
            }

            if (command.UserRequest.PassportSerialNumber != null)
            {
                newUser.PassportSerialNumber = command.UserRequest.PassportSerialNumber;
            }

            if (command.UserRequest.IdentityCardSerialNumber != null)
            {
                newUser.IdentityCardSerialNumber = command.UserRequest.IdentityCardSerialNumber;
            }


            dbCompany.Users.Add(newUser);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
