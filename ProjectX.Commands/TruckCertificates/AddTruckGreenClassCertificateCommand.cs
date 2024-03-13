using MediatR;
using ProjectX.Common.GreenClassCertificate;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TruckCertificates
{
    public record AddTruckGreenClassCertificateCommand : IRequest<string>
    {
        public Guid TruckUid { get; set; }
        public InsertTruckGreenClassCertificateRequest Request { get; set; }

        public AddTruckGreenClassCertificateCommand(Guid truckUid, InsertTruckGreenClassCertificateRequest request)
        {
            TruckUid = truckUid;
            Request = request;
        }
    }

    public record AddTruckGreenClassCertificateCommandHandler : IRequestHandler<AddTruckGreenClassCertificateCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITruckRepository _truckRepository;

        public AddTruckGreenClassCertificateCommandHandler(IUnitOfWork unitOfWork, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _truckRepository = truckRepository;
        }

        public async Task<string> Handle(AddTruckGreenClassCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTruck = await _truckRepository.GetTruckByUidAsync(command.TruckUid);

            var newTruckGreenClassCertificate = new Storage.Entities.GreenClassCertificate.TruckGreenClassCertificate
            {
                CreatedOn = DateTime.UtcNow,
                Uid = Guid.NewGuid(),
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            if (command.Request.EmissionClass != null)
            {
                var newEmissionClass = new Storage.Entities.EmissionClass.EmissionClass
                {
                    Name = command.Request.EmissionClass.Name,
                    Description = command.Request.EmissionClass.Description
                };

                newTruckGreenClassCertificate.EmissionClass = newEmissionClass;
            }

            dbTruck.GreenClassCertificate = newTruckGreenClassCertificate;

            await _unitOfWork.SaveChangesAsync();

            return "Green Class Certificate added.";
        }
    }
}
