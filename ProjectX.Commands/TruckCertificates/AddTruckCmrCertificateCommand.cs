using MediatR;
using ProjectX.Common.CmrCertificate;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TruckCertificates
{
    public record AddTruckCmrCertificateCommand : IRequest<string>
    {
        public Guid TruckUid { get; set; }
        public InsertTruckCmrCertificateRequest Request { get; set; }

        public AddTruckCmrCertificateCommand(Guid truckUid, InsertTruckCmrCertificateRequest request)
        {
            TruckUid = truckUid;
            Request = request;
        }
    }

    public record AddTruckCmrCertificateCommandHandler : IRequestHandler<AddTruckCmrCertificateCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTruckCmrCertificateCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task<string> Handle(AddTruckCmrCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTruck = await _truckRepository.GetTruckByUidAsync(command.TruckUid);

            var newTruckCmrCertificate = new Storage.Entities.CmrCertificate.TruckCmrCertificate
            {
                CreatedOn = DateTime.UtcNow,
                Uid = Guid.NewGuid(),
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            dbTruck.CmrCertificates.Add(newTruckCmrCertificate);

            await _unitOfWork.SaveChangesAsync();

            return "CMR Certificate added.";
        }
    }
}
