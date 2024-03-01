using Domain;
using static Domain.EnumCore;

namespace NPS_WebAPI.Model
{
    public class Creat_Lincense_DTO
    {
        public int CompanyOID { get; set; }
        public string ActivationCode { get; set; }
        public DateTime Lincense_Activated { get; set; }
        public LicenseStatus License_Status { get; set; }

        public string? Device_Name { get; set; }
    }
}
