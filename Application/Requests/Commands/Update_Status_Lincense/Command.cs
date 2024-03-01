using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.EnumCore;

namespace Application.Requests.Commands.Update_Status_Lincense
{
    public partial class Status_Updata
    {
        public class Command : IRequest
        {
            public Guid ID { get; set; }
            public LicenseStatus License_Status { get; set; }
            public Command(Guid ID, LicenseStatus License_Status)
            {
                this.ID = ID;
                this.License_Status = License_Status;
            }
        }
    }
}
