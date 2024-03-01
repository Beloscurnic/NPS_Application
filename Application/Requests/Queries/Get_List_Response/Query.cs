using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Response
{
    public partial class List_Response_Get
    {
        public class Query: IRequest<List_View_Model_Response>
        {
            public int OprostnikID { get; set; }
        }
    }
}
