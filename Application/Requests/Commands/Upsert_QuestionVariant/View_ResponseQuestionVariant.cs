using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_QuestionVariant
{
    public partial class QuestionVaraint_Upsert
    {
        public class View_ResponseQuestionVariant
        {
            public int Questions_VariantID { get; set; }
            public int Key { get; set; }
            public bool IsDeleted { get; set; }
            public string Name { get; set; }
            public int? QuestionID { get; set; }
        }
    }
}
