using MediatR;
using ProjectX.Common.GreenCardCertificate;
using ProjectX.Storage.Repositories.Trailer;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TrailerCertificates
{
    public record AddTrailerGreenCardCertificateCommand : IRequest<string>
    {
        public Guid TrailerUid { get; set; }

        public InsertTrailerGreenCardCertificateRequest Request { get; set; }

        public AddTrailerGreenCardCertificateCommand(Guid trailerUid, InsertTrailerGreenCardCertificateRequest request)
        {
            TrailerUid = trailerUid;
            Request = request;
        }
    }

    public record AddTrailerGreenCardCertificateCommandHandler : IRequestHandler<AddTrailerGreenCardCertificateCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrailerRepository _trailerRepository;

        public AddTrailerGreenCardCertificateCommandHandler(IUnitOfWork unitOfWork, ITrailerRepository trailerRepository)
        {
            _unitOfWork = unitOfWork;
            _trailerRepository = trailerRepository;
        }

        public async Task<string> Handle(AddTrailerGreenCardCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTrailer = await _trailerRepository.GetTrailerByUidAsync(command.TrailerUid);

            var newTrailerGreenCardCertificate = new Storage.Entities.GreenCardCertificate.TrailerGreenCardCertificate
            {
                CreatedOn = DateTime.UtcNow,
                Uid = Guid.NewGuid(),
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            dbTrailer.GreenCardCertificates.Add(newTrailerGreenCardCertificate);

            await _unitOfWork.SaveChangesAsync();

            return "Green Card Certificate added.";
        }
    }
}
