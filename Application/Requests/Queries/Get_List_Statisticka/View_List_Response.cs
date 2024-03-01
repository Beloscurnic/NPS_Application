using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Statisticka
{
    public partial class ListStatistickaGet
    {
        public class View_List_Response
        {
            public DateTime? Data_Creat_Response { get; set; }
            public int ResponseID { get; set; }
            public List<Answer_DB>? Answer_List { get; set; }
            public IDictionary<int, Answer_DB>? Question_Dictionary { get; set; }
        }
        public class Answer_DB
        {
            public int AnswerID { get; set; }
            public int[] Response_Question { get; set; }
            public int QuestionID { get; set; }
            public string Name_Question { get; set; }
        }
    }
}
