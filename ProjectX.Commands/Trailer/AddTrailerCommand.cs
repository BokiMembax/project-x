using MediatR;
using ProjectX.Common.Trailer;
using ProjectX.Storage.Repositories.Company;
using ProjectX.Storage.Repositories.Trailer;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.Trailer
{
    public record AddTrailerCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public InsertTrailerRequest TrailerRequest { get; set; }

        public AddTrailerCommand(Guid companyUid, InsertTrailerRequest trailerRequest)
        {
            CompanyUid = companyUid;
            TrailerRequest = trailerRequest;
        }
    }

    public record AddTrailerCommandHandler : IRequestHandler<AddTrailerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITrailerRepository _trailerRepository;

        public AddTrailerCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository, ITrailerRepository trailerRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
            _trailerRepository = trailerRepository;
        }

        public async Task Handle(AddTrailerCommand command, CancellationToken cancellationToken)
        {
            var dbCompany = await _companyRepository.GetCompanyByUidAsync(command.CompanyUid);

            var trailerExists = await _trailerRepository.DoesTrailerExistAsync(command.TrailerRequest.Vin);

            if (trailerExists)
            {
                throw new Exception($"Trailer exists.");
            }

            var newTrailer = new Storage.Entities.Trailer.Trailer
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                Vin = command.TrailerRequest.Vin,
                ManufacturedOn = command.TrailerRequest.ManufacturedOn,
                Registration = command.TrailerRequest.Registration,
                RegistrationExpiryDate = command.TrailerRequest.RegistrationExpiryDate,
                Company = dbCompany
            };

            dbCompany.Trailers.Add(newTrailer);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
