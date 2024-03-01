using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_QuestionVariant
{
    public partial class QuestionVariant_Get
    {
        public class Query: IRequest<ViewModelQuestionVariant>
        {
            public int QuestionVariant_ID { get; set; }
        }
    }
}
