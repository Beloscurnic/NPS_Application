using static Domain.EnumCore;

namespace NPS_WebAPI.Model
{
    public class Update_Lincense_Status
    {
        public Guid ID { get; set; }
        public LicenseStatus LicenseStatus { get; set; }
    }
}
