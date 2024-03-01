using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Response
{
    public partial class Response_Delit
    {
        public class Command : IRequest
        {
            public int Response_ID { get; set; }
        }
    }
}
