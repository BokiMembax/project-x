﻿using MediatR;
using ProjectX.Common.CemtCertificate;
using ProjectX.Storage.Repositories.Trailer;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Commands.TrailerCertificates
{
    public record AddTrailerCemtCertificateCommand : IRequest
    {
        public Guid CompanyUid { get; set; }
        public Guid TrailerUid { get; set; }
        public InsertTrailerCemtCertificateRequest Request { get; set; }

        public AddTrailerCemtCertificateCommand(Guid companyUid, Guid trailerUid, InsertTrailerCemtCertificateRequest request)
        {
            CompanyUid = companyUid;
            TrailerUid = trailerUid;
            Request = request;
        }
    }

    public record AddTrailerCemtCertificateCommandHandler : IRequestHandler<AddTrailerCemtCertificateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrailerRepository _trailerRepository;

        public AddTrailerCemtCertificateCommandHandler(IUnitOfWork unitOfWork, ITrailerRepository trailerRepository)
        {
            _unitOfWork = unitOfWork;
            _trailerRepository = trailerRepository;
        }

        public async Task Handle(AddTrailerCemtCertificateCommand command, CancellationToken cancellationToken)
        {
            var dbTrailer = await _trailerRepository.GetTrailerByUidAsync(command.CompanyUid, command.TrailerUid);

            var newTrailerCemtCertificate = new Storage.Entities.CemtCertificate.TrailerCemtCertificate
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,                
                ExpiryDate = command.Request.ExpiryDate,
                IsExpired = command.Request.IsExpired
            };

            dbTrailer.CemtCertificates.Add(newTrailerCemtCertificate);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
