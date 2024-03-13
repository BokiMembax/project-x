using MediatR;
using ProjectX.Common.YellowCertificate;
using ProjectX.Storage.Repositories.Trailer;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TrailerCertificates
{
    public record AddTrailerYellowCertificateCommand : IRequest<string>
    {
        public Guid TrailerUid { get; set; }

        public InsertTrailerYellowCertificateRequest Request { get; set; }

        public AddTrailerYellowCertificateCommand(Guid trailerUid, InsertTrailerYellowCertificateRequest request)
        {
            TrailerUid = trailerUid;
            Request = request;
        }
    }

    public record AddTrailerYellowCertificateCommandHandler : IRequestHandler<AddTrailerYellowCertificateCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrailerRepository _trailerRepository;

        public AddTrailerYellowCertificateCommandHandler(IUnitOfWork unitOfWork, ITrailerRepository trailerRepository)
        {
            _unitOfWork = unitOfWork;
            _trailerRepository = trailerRepository;
        }

        public async Task<string> Handle(AddTrailerYellowCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTrailer = await _trailerRepository.GetTrailerByUidAsync(command.TrailerUid);

            var newTrailerYellowCertificate = new Storage.Entities.YellowCertificate.TrailerYellowCertificate
            {
                CreatedOn = DateTime.UtcNow,
                Uid = Guid.NewGuid(),
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            dbTrailer.YellowCertificates.Add(newTrailerYellowCertificate);

            await _unitOfWork.SaveChangesAsync();

            return "Yellow Certificate added.";
        }
    }
}
