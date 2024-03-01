using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.EnumCore;

namespace Application.Requests.Commands.Add_Lincense
{
    public partial class Creat_Lincense
    {
        public class Command : IRequest<View_Response>

        {
            public int CompanyOID { get; set; }
            public string ActivationCode { get; set; }
            public DateTime Lincense_Activated { get; set; }
            public LicenseStatus License_Status { get; set; }

            public string? Device_Name { get; set; }
            public Command( int companyOID, string activationCode, DateTime lincense_Activated, LicenseStatus license_Status, string? device_Name)
            {
                CompanyOID = companyOID;
                ActivationCode = activationCode;
                Lincense_Activated = lincense_Activated;
                License_Status = license_Status;
                Device_Name = device_Name;
            }
        }
    }
}