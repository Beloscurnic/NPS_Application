using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.EnumCore;

namespace Application.Requests.Commands.Update_Status_Question
{
    public partial class Status_Question_Update
    {
        public class Command :IRequest
        {
            public int QuestionID { get; set; }
            public Status_Question Status_Question { get; set; }
        }
    }
}
