using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Requests.Queries.Get_List_Question.List_Question_Get;

namespace Application.Requests.Commands.Upsert_QuestionVariant
{
    public partial class QuestionVaraint_Upsert
    {
        public class CommandListQuestionVariant : IRequest<ListViewResponseQuestionVariant>
        {
            public IList<Command> QuestionVariant_Commands { get; set; }
            public int? QuestionID { get; set; }
            public int? OprostnikID { get; set; }
        }
    }
}
