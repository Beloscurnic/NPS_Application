using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_QuestionVariant
{
    public partial class QuestionVariant_Get_List
    {
        public class Query: IRequest<List_ViewModelQuestionVariant> 
        {
            public int QuestionID { get; set; } 
        }
    }
}
