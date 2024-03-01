using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_QuestionVariant
{
    public partial class QuestionVariant_Get_List
    {
        public class View_ModelQuestionVariant
        {
            public int Questions_VariantID { get; set; }
            public int Key { get; set; }
            public bool IsDeleted { get; set; }
            public string Name { get; set; }
            public int? QuestionID { get; set; }
        }
    }
}
