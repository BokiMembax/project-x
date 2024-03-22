using MediatR;
using ProjectX.Common.CmrCertificate;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TruckCertificates
{
    public record AddTruckCmrCertificateCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public Guid TruckUid { get; set; }
        public InsertTruckCmrCertificateRequest Request { get; set; }

        public AddTruckCmrCertificateCommand(Guid companyUid, Guid truckUid, InsertTruckCmrCertificateRequest request)
        {
            CompanyUid = companyUid;
            TruckUid = truckUid;
            Request = request;
        }
    }

    public record AddTruckCmrCertificateCommandHandler : IRequestHandler<AddTruckCmrCertificateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTruckCmrCertificateCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task Handle(AddTruckCmrCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTruck = await _truckRepository.GetTruckByUidAsync(command.CompanyUid, command.TruckUid);

            var newTruckCmrCertificate = new Storage.Entities.CmrCertificate.TruckCmrCertificate
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired,
                Truck = dbTruck
            };

            dbTruck.CmrCertificates.Add(newTruckCmrCertificate);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
