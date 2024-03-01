using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Question
{
    public partial class Question_Get
    {
        public class Query: IRequest<ViewModelQuestion>
        {
            public int Question_ID { get; set; }

        }
    }
}
