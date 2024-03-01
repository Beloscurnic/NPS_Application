using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Answer
{
    public partial class Answer_Get
    {
        public class Query: IRequest<ViewModelAnswert>
        {
            public int AnswertID { get; set; }
        }
    }
}
