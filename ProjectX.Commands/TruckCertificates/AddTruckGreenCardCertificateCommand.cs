using MediatR;
using ProjectX.Common.GreenCardCertificate;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TruckCertificates
{
    public record AddTruckGreenCardCertificateCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public Guid TruckUid { get; set; }
        public InsertTruckGreenCardCertificateRequest Request { get; set; }

        public AddTruckGreenCardCertificateCommand(Guid companyUid, Guid truckUid, InsertTruckGreenCardCertificateRequest request)
        {
            CompanyUid = companyUid;
            TruckUid = truckUid;
            Request = request;
        }
    }

    public record AddTruckGreenCardCertificateCommandHandler : IRequestHandler<AddTruckGreenCardCertificateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTruckGreenCardCertificateCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task Handle(AddTruckGreenCardCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTruck = await _truckRepository.GetTruckByUidAsync(command.CompanyUid, command.TruckUid);

            var newTruckGreenCardCertificate = new Storage.Entities.GreenCardCertificate.TruckGreenCardCertificate
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired,
                Truck = dbTruck
            };

            dbTruck.GreenCardCertificates.Add(newTruckGreenCardCertificate);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
