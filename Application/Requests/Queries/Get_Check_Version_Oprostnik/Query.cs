using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Check_Version_Oprostnik
{
    public partial class Check_Version_Oprostnik_Get
    {
        public class Query: IRequest<bool>
        {
            public int OprostnikId { get; set;}
            public DateTime Data_Used { get; set;}  
        }
    }
}
