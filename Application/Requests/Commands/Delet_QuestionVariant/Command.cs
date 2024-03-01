using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_QuestionVariant
{
    public partial class QuestionVariant_Delet
    {
        public class Command :IRequest
        {
            public int QuestionVariantID { get; set; }
            public int OprostnikID { get; set; }
        }
    }
}
