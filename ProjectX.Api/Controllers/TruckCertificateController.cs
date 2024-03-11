//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using ProjectX.Common.CemtCertificate;
//using ProjectX.Common.CmrCertificate;
//using ProjectX.Common.GreenCardCertificate;
//using ProjectX.Common.Tachograph;

//namespace ProjectX.Api.Controllers
//{
//    [ApiController]
//    [Route("api/companies/{companyUid}/trucks/{truckUid}/certificates")]
//    public class TruckCertificateController : ControllerBase
//    {
//        private readonly ILogger<TruckCertificateController> _logger;
//        private readonly ISender _sender;

//        public TruckCertificateController(ILogger<TruckCertificateController> logger, ISender sender)
//        {
//            _logger = logger;
//            _sender = sender;
//        }

//        [HttpPost("cemt")]
//        public async Task<CemtCertificateResponseDto> AddCemtCertificate([FromRoute] Guid truckUid, InsertTruckCemtCertificateRequest request)
//        {
//            return await _sender.Send(new AddCemtCertificateCommand(truckUid, request));
//        }

//        [HttpPost("cmr")]
//        public async Task<CmrCertificateResponseDto> AddCmrCertificate([FromRoute] Guid truckUid, InsertTruckCmrCertificateRequest request)
//        {
//            return await _sender.Send(new AddCmrCertificateCommand(truckUid, request));
//        }

//        [HttpPost("tachograph")]
//        public async Task<TachographResponseDto> AddTachograph([FromRoute] Guid truckUid, InsertTachographRequest request)
//        {
//            return await _sender.Send(new AddTachographCommand(truckUid, request));
//        }

//        [HttpPost("greencard")]
//        public async Task<GreenCardCertificateResponseDto> AddGreenCardCertificate([FromRoute] Guid truckUid, InsertTruckGreenCardCertificateRequest request)
//        {
//            return await _sender.Send(new AddGreenCardCertificateCommand(truckUid, request));
//        }

//        [HttpPost]
//        [Route("emissionclass")]
//        public async Task<EmissionClassBaseResponse> InsertEmissionClassCertificate([FromUri] Guid truckUid, EmissionClassCertificateRequest request)
//        {
//            return await _vehicleService.InsertEmissionClassCertificateAsync(truckUid, request);
//        }
//    }
//}
