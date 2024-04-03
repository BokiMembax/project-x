using MediatR;
using ProjectX.Common.CemtCertificate;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TruckCertificates
{
    public record AddTruckCemtCertificateCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public Guid TruckUid { get; set; }
        public InsertTruckCemtCertificateRequest Request { get; set; }

        public AddTruckCemtCertificateCommand(Guid companyUid, Guid truckUid, InsertTruckCemtCertificateRequest request)
        {
            CompanyUid = companyUid;
            TruckUid = truckUid;
            Request = request;
        }
    }

    public record AddTruckCemtCertificateCommandHandler : IRequestHandler<AddTruckCemtCertificateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTruckCemtCertificateCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task Handle(AddTruckCemtCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTruck = await _truckRepository.GetTruckByUidAsync(command.CompanyUid, command.TruckUid);

            var newTruckCemtCertificate = new Storage.Entities.CemtCertificate.TruckCemtCertificate
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,                
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired,
                Truck = dbTruck
            };

            dbTruck.CemtCertificates.Add(newTruckCemtCertificate);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
