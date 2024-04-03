using MediatR;
using ProjectX.Common.GreenCardCertificate;
using ProjectX.Storage.Repositories.Trailer;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TrailerCertificates
{
    public record AddTrailerGreenCardCertificateCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public Guid TrailerUid { get; set; }
        public InsertTrailerGreenCardCertificateRequest Request { get; set; }

        public AddTrailerGreenCardCertificateCommand(Guid companyUid, Guid trailerUid, InsertTrailerGreenCardCertificateRequest request)
        {
            CompanyUid = companyUid;
            TrailerUid = trailerUid;
            Request = request;
        }
    }

    public record AddTrailerGreenCardCertificateCommandHandler : IRequestHandler<AddTrailerGreenCardCertificateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrailerRepository _trailerRepository;

        public AddTrailerGreenCardCertificateCommandHandler(IUnitOfWork unitOfWork, ITrailerRepository trailerRepository)
        {
            _unitOfWork = unitOfWork;
            _trailerRepository = trailerRepository;
        }

        public async Task Handle(AddTrailerGreenCardCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTrailer = await _trailerRepository.GetTrailerByUidAsync(command.CompanyUid, command.TrailerUid);

            var newTrailerGreenCardCertificate = new Storage.Entities.GreenCardCertificate.TrailerGreenCardCertificate
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,                
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            dbTrailer.GreenCardCertificates.Add(newTrailerGreenCardCertificate);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
