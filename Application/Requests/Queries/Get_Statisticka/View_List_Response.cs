using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Domain.EnumCore;

namespace Application.Requests.Queries.Get_Statisticka
{
    public partial class Statisticka_Get
    {
        public class View_List_Response
        {
          public DateTime?  Data_Creat_Response { get; set; }
          public int ResponseID { get; set; } 
           public Answer_DB? Answer { get; set; }

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