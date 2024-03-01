using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Update_Status_QuestionVariant
{
    public partial class QuestionVariant_Status_Update
    {
        public class Command :IRequest
        {
            public int QuestionVariant_ID { get; set; }
            public int Oprostnik_ID { get; set; }
        }
    }
}
