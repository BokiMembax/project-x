using MediatR;
using ProjectX.Common.Company;
using ProjectX.Storage.Repositories.Company;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.Company
{
    public class AddCompanyCommand : IRequest<string>
    {
        public InsertCompanyRequest CompanyRequest { get; set; }

        public AddCompanyCommand(InsertCompanyRequest companyRequest)
        {
            CompanyRequest = companyRequest;
        }
    }

    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;

        public AddCompanyCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        public async Task<string> Handle(AddCompanyCommand command, CancellationToken cancellationToken)
        {
            var companyExists = await _companyRepository.DoesCompanyExistAsync(command.CompanyRequest.Embs, command.CompanyRequest.Email);

            if (companyExists)
            {
                throw new Exception($"Company with Embs: {command.CompanyRequest.Embs} and Email: {command.CompanyRequest.Email} exists.");
            }

            var newCompany = new Storage.Entities.Company.Company
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,                                
                Embs = command.CompanyRequest.Embs,
                Name = command.CompanyRequest.Name,
                Address = command.CompanyRequest.Address,
                Email = command.CompanyRequest.Email,
                PhoneNumber = command.CompanyRequest.PhoneNumber
            };

            await _companyRepository.InsertCompanyAsync(newCompany);


            await _unitOfWork.SaveChangesAsync();

            return $"Company with Embs: {command.CompanyRequest.Embs} and Email: {command.CompanyRequest.Email} added.";
        }
    }
}
