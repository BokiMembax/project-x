using MediatR;
using ProjectX.Common.Tachograph;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TruckCertificates
{
    public record AddTachographCommand : IRequest<string>
    {
        public Guid TruckUid { get; set; }
        public InsertTachographRequest Request { get; set; }

        public AddTachographCommand(Guid truckUid, InsertTachographRequest request)
        {
            TruckUid = truckUid;
            Request = request;
        }
    }

    public record AddTachographCommandHandler : IRequestHandler<AddTachographCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTachographCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task<string> Handle(AddTachographCommand command, CancellationToken cancellationToken)
        {
            var dbTruck = await _truckRepository.GetTruckByUidAsync(command.TruckUid);

            var newTachograph = new Storage.Entities.Tachograph.Tachograph
            {
                CreatedOn = DateTime.UtcNow,
                Uid = Guid.NewGuid(),
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            dbTruck.Tachographs.Add(newTachograph);

            await _unitOfWork.SaveChangesAsync();

            return "Tachograph added.";
        }
    }
}
