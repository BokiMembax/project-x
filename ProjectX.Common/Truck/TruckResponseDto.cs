using ProjectX.Common.CemtCertificate;
using ProjectX.Common.CmrCertificate;
using ProjectX.Common.GreenCardCertificate;
using ProjectX.Common.Tachograph;

namespace ProjectX.Common.Truck
{
    public class TruckResponseDto
    {
        public string CombinationNumber { get; set; } = string.Empty;

        public string Vin { get; set; } = string.Empty;

        public DateTime ManufacturedOn { get; set; }

        public string Registration { get; set; } = string.Empty;

        public DateTime? RegistrationExpiryDate { get; set; }

        public ICollection<CemtCertificateResponseDto> CemtCertificates { get; set; } = new List<CemtCertificateResponseDto>();

        public ICollection<CmrCertificateResponseDto> CmrCertificates { get; set; } = new List<CmrCertificateResponseDto>();

        public ICollection<TachographResponseDto> Tachographs { get; set; } = new List<TachographResponseDto>();

        public ICollection<GreenCardCertificateResponseDto> GreenCardCertificates { get; set; } = new List<GreenCardCertificateResponseDto>();
    }
}
