﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Commands.TruckCertificates;
using ProjectX.Common.CemtCertificate;
using ProjectX.Common.CmrCertificate;
using ProjectX.Common.GreenCardCertificate;
using ProjectX.Common.GreenClassCertificate;
using ProjectX.Common.Tachograph;

namespace ProjectX.Api.Controllers
{
    [ApiController]
    [Route("api/companies/{companyUid}/trucks/{truckUid}/certificates")]
    public class TruckCertificateController : ControllerBase
    {
        private readonly ILogger<TruckCertificateController> _logger;
        private readonly ISender _sender;

        public TruckCertificateController(ILogger<TruckCertificateController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost]
        [Route("cemt")]
        public async Task AddTruckCemtCertificate([FromRoute] Guid companyUid, [FromRoute] Guid truckUid, InsertTruckCemtCertificateRequest request)
        {
            await _sender.Send(new AddTruckCemtCertificateCommand(companyUid, truckUid, request));
        }

        [HttpPost]
        [Route("cmr")]
        public async Task AddTruckCmrCertificate([FromRoute] Guid companyUid, [FromRoute] Guid truckUid, InsertTruckCmrCertificateRequest request)
        {
            await _sender.Send(new AddTruckCmrCertificateCommand(companyUid, truckUid, request));
        }

        [HttpPost]
        [Route("tachograph")]
        public async Task AddTachograph([FromRoute] Guid companyUid, [FromRoute] Guid truckUid, InsertTachographRequest request)
        {
            await _sender.Send(new AddTachographCommand(companyUid, truckUid, request));
        }

        [HttpPost]
        [Route("greencard")]
        public async Task AddTruckGreenCardCertificate([FromRoute] Guid companyUid, [FromRoute] Guid truckUid, InsertTruckGreenCardCertificateRequest request)
        {
            await _sender.Send(new AddTruckGreenCardCertificateCommand(companyUid, truckUid, request));
        }

        [HttpPost]
        [Route("greenclass")]
        public async Task AddTruckGreenClassCertificate([FromRoute] Guid companyUid, [FromRoute] Guid truckUid, InsertTruckGreenClassCertificateRequest request)
        {
            await _sender.Send(new AddTruckGreenClassCertificateCommand(companyUid, truckUid, request));
        }
    }
}
