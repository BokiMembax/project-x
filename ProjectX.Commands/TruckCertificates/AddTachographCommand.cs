using MediatR;
using ProjectX.Common.Tachograph;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TruckCertificates
{
    public record AddTachographCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public Guid TruckUid { get; set; }
        public InsertTachographRequest Request { get; set; }

        public AddTachographCommand(Guid companyUid, Guid truckUid, InsertTachographRequest request)
        {
            CompanyUid = companyUid;
            TruckUid = truckUid;
            Request = request;
        }
    }

    public record AddTachographCommandHandler : IRequestHandler<AddTachographCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTachographCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task Handle(AddTachographCommand command, CancellationToken cancellationToken)
        {
            var dbTruck = await _truckRepository.GetTruckByUidAsync(command.CompanyUid, command.TruckUid);

            var newTachograph = new Storage.Entities.Tachograph.Tachograph
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,                
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired,
                Truck = dbTruck
            };

            dbTruck.Tachographs.Add(newTachograph);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
