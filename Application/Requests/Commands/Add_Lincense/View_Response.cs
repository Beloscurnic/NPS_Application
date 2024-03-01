using Domain;
using System.ComponentModel.Design;
using static Domain.EnumCore;

namespace Application.Requests.Commands.Add_Lincense
{
    public partial class Creat_Lincense
    {
        public class View_Response
        {
            public Guid ID { get; set; }
            public int CompanyOID { get; set; }
        //    public GroupQuestionnaire? Group_Questionnaire { get; set; }
            public string ActivationCode { get; set; }
            public DateTime Lincense_Activated { get; set; }
            public LicenseStatus License_Status { get; set; }

            public string? Device_Name { get; set; }

            public View_Response(Lincense lincense)
            {
                ID = lincense.LincenseID;
                CompanyOID = lincense.CompanyOID;
                ActivationCode = lincense.ActivationCode;
                Lincense_Activated = lincense.Lincense_Activated;
                License_Status = lincense.License_Status;
                Device_Name = lincense.Device_Name;
            }
        }
    }
}
