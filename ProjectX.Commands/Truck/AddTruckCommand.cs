using MediatR;
using ProjectX.Common.Truck;
using ProjectX.Storage.Repositories.Company;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.Truck
{
    public record AddTruckCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public InsertTruckRequest TruckRequest { get; set; }

        public AddTruckCommand(Guid companyUid, InsertTruckRequest truckRequest)
        {
            CompanyUid = companyUid;
            TruckRequest = truckRequest;
        }
    }

    public record AddTruckCommandHandler : IRequestHandler<AddTruckCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITruckRepository _truckRepository;

        public AddTruckCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
            _truckRepository = truckRepository;
        }

        public async Task Handle(AddTruckCommand command, CancellationToken cancellationToken)
        {
            var dbCompany = await _companyRepository.GetCompanyByUidAsync(command.CompanyUid);

            var truckExists = await _truckRepository.DoesTruckExistAsync(command.TruckRequest.Vin);

            if (truckExists)
            {
                throw new Exception($"Truck exists.");
            }

            var newTruck = new Storage.Entities.Truck.Truck
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                CombinationNumber = command.TruckRequest.CombinationNumber,
                Vin = command.TruckRequest.Vin,
                ManufacturedOn = command.TruckRequest.ManufacturedOn,
                Registration = command.TruckRequest.Registration,
                RegistrationExpiryDate = command.TruckRequest.RegistrationExpiryDate,
                Company = dbCompany
            };

            dbCompany.Trucks.Add(newTruck);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
