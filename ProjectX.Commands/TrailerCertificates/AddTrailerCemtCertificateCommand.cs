using MediatR;
using ProjectX.Common.CemtCertificate;
using ProjectX.Storage.Repositories.Trailer;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TrailerCertificates
{
    public record AddTrailerCemtCertificateCommand : IRequest<string>
    {
        public Guid TrailerUid { get; set; }
        public InsertTrailerCemtCertificateRequest Request { get; set; }

        public AddTrailerCemtCertificateCommand(Guid trailerUid, InsertTrailerCemtCertificateRequest request)
        {
            TrailerUid = trailerUid;
            Request = request;
        }
    }

    public record AddTrailerCemtCertificateCommandHandler : IRequestHandler<AddTrailerCemtCertificateCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrailerRepository _trailerRepository;

        public AddTrailerCemtCertificateCommandHandler(IUnitOfWork unitOfWork, ITrailerRepository trailerRepository)
        {
            _unitOfWork = unitOfWork;
            _trailerRepository = trailerRepository;
        }

        public async Task<string> Handle(AddTrailerCemtCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTrailer = await _trailerRepository.GetTrailerByUidAsync(command.TrailerUid);

            var newTrailerCemtCertificate = new Storage.Entities.CemtCertificate.TrailerCemtCertificate
            {
                CreatedOn = DateTime.UtcNow,
                Uid = Guid.NewGuid(),
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            dbTrailer.CemtCertificates.Add(newTrailerCemtCertificate);

            await _unitOfWork.SaveChangesAsync();

            return "CEMT Certificate added.";
        }
    }
}
