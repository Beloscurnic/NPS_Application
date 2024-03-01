using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Question
{
    public partial class Question_Delet
    {
        public class Command :IRequest
        {
            public int Question_ID { get; set; }
        }
    }
}
