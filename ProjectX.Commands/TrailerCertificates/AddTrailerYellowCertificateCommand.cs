using MediatR;
using ProjectX.Common.YellowCertificate;
using ProjectX.Storage.Repositories.Trailer;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TrailerCertificates
{
    public record AddTrailerYellowCertificateCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public Guid TrailerUid { get; set; }
        public InsertTrailerYellowCertificateRequest Request { get; set; }

        public AddTrailerYellowCertificateCommand(Guid companyUid, Guid trailerUid, InsertTrailerYellowCertificateRequest request)
        {
            CompanyUid = companyUid;
            TrailerUid = trailerUid;
            Request = request;
        }
    }

    public record AddTrailerYellowCertificateCommandHandler : IRequestHandler<AddTrailerYellowCertificateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrailerRepository _trailerRepository;

        public AddTrailerYellowCertificateCommandHandler(IUnitOfWork unitOfWork, ITrailerRepository trailerRepository)
        {
            _unitOfWork = unitOfWork;
            _trailerRepository = trailerRepository;
        }

        public async Task Handle(AddTrailerYellowCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTrailer = await _trailerRepository.GetTrailerByUidAsync(command.CompanyUid, command.TrailerUid);

            var newTrailerYellowCertificate = new Storage.Entities.YellowCertificate.TrailerYellowCertificate
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            dbTrailer.YellowCertificates.Add(newTrailerYellowCertificate);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
