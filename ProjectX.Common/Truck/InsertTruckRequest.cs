using ProjectX.Common.CemtCertificate;
using ProjectX.Common.CmrCertificate;
using ProjectX.Common.GreenCardCertificate;
using ProjectX.Common.Tachograph;

namespace ProjectX.Common.Truck
{
    public class InsertTruckRequest
    {
        public string CombinationNumber { get; set; } = string.Empty;

        public string Vin { get; set; } = string.Empty;

        public DateTime ManufacturedOn { get; set; }

        public string Registration { get; set; } = string.Empty;

        public DateTime? RegistrationExpiryDate { get; set; }

        public ICollection<InsertTruckCemtCertificateRequest> CemtCertificates { get; set; } = new List<InsertTruckCemtCertificateRequest>();

        public ICollection<InsertTruckCmrCertificateRequest> CmrCertificates { get; set; } = new List<InsertTruckCmrCertificateRequest>();

        public ICollection<InsertTachographRequest> Tachographs { get; set; } = new List<InsertTachographRequest>();

        public ICollection<InsertTruckGreenCardCertificateRequest> GreenCardCertificates { get; set; } = new List<InsertTruckGreenCardCertificateRequest>();
    }
}
