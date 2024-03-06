using MediatR;
using ProjectX.Common.Truck;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.Truck
{
    public record AddTruckCommand : IRequest<string>
    {
        public InsertTruckRequest TruckRequest { get; set; }

        public AddTruckCommand(InsertTruckRequest truckRequest)
        {
            TruckRequest = truckRequest;
        }
    }

    public record AddTruckCommandHandler : IRequestHandler<AddTruckCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTruckCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task<string> Handle(AddTruckCommand command, CancellationToken cancellationToken)
        {
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
                RegistrationExpiryDate = command.TruckRequest.RegistrationExpiryDate
            };

            await _truckRepository.InsertTruckAsync(newTruck);

            await _unitOfWork.SaveChangesAsync();

            return "Truck added.";
        }
    }
}
