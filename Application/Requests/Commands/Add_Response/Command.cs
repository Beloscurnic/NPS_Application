using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Add_Response
{
    public partial class Response_Add
    {
        public class Command : IRequest<ViewCreatResponse>
        {
            public IList<CommandAnswert>? Answers { get; set; }
            public int OprostnikID { get; set; }
        }
    }
}
