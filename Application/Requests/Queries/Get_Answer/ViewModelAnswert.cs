using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.EnumCore;

namespace Application.Requests.Queries.Get_Answer
{
    public partial class Answer_Get
    {
        public class ViewModelAnswert
        {
            public int AnswerID { get; set; }
            public TypeQuestion TypeQuestion { get; set; }
            public string Response_Question { get; set; }
            public int ResponseID { get; set; }
            public int QuestionID { get; set; }
        }
    }
}
