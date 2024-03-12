using MediatR;
using ProjectX.Common.CemtCertificate;
using ProjectX.Common.CmrCertificate;
using ProjectX.Common.GreenCardCertificate;
using ProjectX.Common.Tachograph;
using ProjectX.Common.Truck;
using ProjectX.Storage.Repositories.Company;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.Truck
{
    public record AddTruckCommand : IRequest<string>
    {
        public Guid CompanyUid { get; set; }
        public InsertTruckRequest TruckRequest { get; set; }

        public AddTruckCommand(Guid companyUid, InsertTruckRequest truckRequest)
        {
            CompanyUid = companyUid;
            TruckRequest = truckRequest;
        }
    }

    public record AddTruckCommandHandler : IRequestHandler<AddTruckCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITruckRepository _truckRepository;

        public AddTruckCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository, ITruckRepository truckRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
            _truckRepository = truckRepository;
        }

        public async Task<string> Handle(AddTruckCommand command, CancellationToken cancellationToken)
        {
            var dbCompany = await _companyRepository.GetCompanyByUidAsync(command.CompanyUid);

            var truckExists = await _truckRepository.DoesTruckExistAsync(command.TruckRequest.Vin);

            if (truckExists)
            {
                throw new Exception($"Truck exists.");
            }

            var newTruck = new Storage.Entities.Truck.Truck
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                CombinationNumber = command.TruckRequest.CombinationNumber,
                Vin = command.TruckRequest.Vin,
                ManufacturedOn = command.TruckRequest.ManufacturedOn,
                Registration = command.TruckRequest.Registration,
                RegistrationExpiryDate = command.TruckRequest.RegistrationExpiryDate,
                Company = dbCompany
            };

            //foreach (InsertTruckCemtCertificateRequest cemtCertificateRequest in command.TruckRequest.CemtCertificates)
            //{
            //    var newTruckCemtCertificate = new Storage.Entities.CemtCertificate.TruckCemtCertificate
            //    {
            //        CreatedOn = DateTime.UtcNow,
            //        Uid = Guid.NewGuid(),
            //        ExpiryDate = cemtCertificateRequest.ExpiryDate,
            //        IsExpired = cemtCertificateRequest.IsExpired
            //    };

            //    newTruck.CemtCertificates.Add(newTruckCemtCertificate);
            //}

            //foreach (InsertTruckCmrCertificateRequest cmrCertificateRequest in command.TruckRequest.CmrCertificates)
            //{
            //    var newTruckCmrCertificate = new Storage.Entities.CmrCertificate.TruckCmrCertificate
            //    {
            //        CreatedOn = DateTime.UtcNow,
            //        Uid = Guid.NewGuid(),
            //        ExpiryDate = cmrCertificateRequest.ExpiryDate,
            //        IsExpired = cmrCertificateRequest.IsExpired
            //    };

            //    newTruck.CmrCertificates.Add(newTruckCmrCertificate);
            //}

            //foreach (InsertTachographRequest tachographRequest in command.TruckRequest.Tachographs)
            //{
            //    var newTachograph = new Storage.Entities.Tachograph.Tachograph
            //    {
            //        CreatedOn = DateTime.UtcNow,
            //        Uid = Guid.NewGuid(),
            //        ExpiryDate = tachographRequest.ExpiryDate,
            //        IsExpired = tachographRequest.IsExpired
            //    };

            //    newTruck.Tachographs.Add(newTachograph);
            //}

            //foreach (InsertTruckGreenCardCertificateRequest truckGreenCardCertificateRequest in command.TruckRequest.GreenCardCertificates)
            //{
            //    var newTruckGreenCardCertificate = new Storage.Entities.GreenCardCertificate.TruckGreenCardCertificate
            //    {
            //        CreatedOn = DateTime.UtcNow,
            //        Uid = Guid.NewGuid(),
            //        ExpiryDate = truckGreenCardCertificateRequest.ExpiryDate,
            //        IsExpired = truckGreenCardCertificateRequest.IsExpired
            //    };

            //    newTruck.GreenCardCertificates.Add(newTruckGreenCardCertificate);
            //}

            dbCompany.Trucks.Add(newTruck);

            await _truckRepository.InsertTruckAsync(newTruck);

            await _unitOfWork.SaveChangesAsync();

            return "Truck added.";
        }
    }
}
