using MediatR;
using ProjectX.Common.CemtCertificate;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TruckCertificates
{
    public record AddTruckCemtCertificateCommand : IRequest<string>
    {
        public Guid TruckUid { get; set; }
        public InsertTruckCemtCertificateRequest Request { get; set; }

        public AddTruckCemtCertificateCommand(Guid truckUid, InsertTruckCemtCertificateRequest request)
        {
            TruckUid = truckUid;
            Request = request;
        }
    }

    public record AddTruckCemtCertificateCommandHandler : IRequestHandler<AddTruckCemtCertificateCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTruckCemtCertificateCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task<string> Handle(AddTruckCemtCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTruck = await _truckRepository.GetTruckByUidAsync(command.TruckUid);

            var newTruckCemtCertificate = new Storage.Entities.CemtCertificate.TruckCemtCertificate
            {
                CreatedOn = DateTime.UtcNow,
                Uid = Guid.NewGuid(),
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            dbTruck.CemtCertificates.Add(newTruckCemtCertificate);

            await _unitOfWork.SaveChangesAsync();

            return "CEMT Certificate added.";
        }
    }
}
