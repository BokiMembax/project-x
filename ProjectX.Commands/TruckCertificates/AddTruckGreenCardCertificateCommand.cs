using MediatR;
using ProjectX.Common.GreenCardCertificate;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TruckCertificates
{
    public record AddTruckGreenCardCertificateCommand : IRequest<string>
    {
        public Guid TruckUid { get; set; }
        public InsertTruckGreenCardCertificateRequest Request { get; set; }

        public AddTruckGreenCardCertificateCommand(Guid truckUid, InsertTruckGreenCardCertificateRequest request)
        {
            TruckUid = truckUid;
            Request = request;
        }
    }

    public record AddTruckGreenCardCertificateCommandHandler : IRequestHandler<AddTruckGreenCardCertificateCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTruckGreenCardCertificateCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task<string> Handle(AddTruckGreenCardCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTruck = await _truckRepository.GetTruckByUidAsync(command.TruckUid);

            var newTruckGreenCardCertificate = new Storage.Entities.GreenCardCertificate.TruckGreenCardCertificate
            {
                CreatedOn = DateTime.UtcNow,
                Uid = Guid.NewGuid(),
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            dbTruck.GreenCardCertificates.Add(newTruckGreenCardCertificate);

            await _unitOfWork.SaveChangesAsync();

            return "Green Card Certificate added.";
        }
    }
}
