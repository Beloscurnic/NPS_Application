using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Oprostnik
{
    public partial class Oprostnik_Delet
    {
        public class Command:IRequest
            
        {
            public int ID_Oprostniks { get; set; }
        }
    }
}