using MediatR;
using ProjectX.Common.GreenClassCertificate;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TruckCertificates
{
    public record AddTruckGreenClassCertificateCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public Guid TruckUid { get; set; }
        public InsertTruckGreenClassCertificateRequest Request { get; set; }

        public AddTruckGreenClassCertificateCommand(Guid companyUid, Guid truckUid, InsertTruckGreenClassCertificateRequest request)
        {
            CompanyUid = companyUid;
            TruckUid = truckUid;
            Request = request;
        }
    }

    public record AddTruckGreenClassCertificateCommandHandler : IRequestHandler<AddTruckGreenClassCertificateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTruckGreenClassCertificateCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task Handle(AddTruckGreenClassCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTruck = await _truckRepository.GetTruckByUidAsync(command.CompanyUid, command.TruckUid);

            var newTruckGreenClassCertificate = new Storage.Entities.GreenClassCertificate.TruckGreenClassCertificate
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,                
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired,
                EmissionClassName = command.Request.EmissionClassName,
                EmissionClassDescription = command.Request.EmissionClassDescription
            };

            dbTruck.GreenClassCertificate = newTruckGreenClassCertificate;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
