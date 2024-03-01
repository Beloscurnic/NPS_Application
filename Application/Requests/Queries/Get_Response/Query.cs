using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Response
{
    public partial class Response_Get
    {
        public class Query: IRequest<ViewModelResponse>
        {
            public int Response_ID { get; set; }    
        }
    }
}
