using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Answert
{
    public partial class Answert_Delet
    {
        public class Command: IRequest
        {
            public int AnswertId { get; set; }
        }
    }
}
