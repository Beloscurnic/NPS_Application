using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_QuestionVariant
{

    public partial class QuestionVaraint_Upsert
    {
        public class ListViewResponseQuestionVariant
        {
            public IList<View_ResponseQuestionVariant> ResultsResponse { get; set; } = new List<View_ResponseQuestionVariant>();
        }
    }
}
