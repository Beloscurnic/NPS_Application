﻿using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.EnumCore;

namespace Application.Requests.Queries.Get_Response
{
    public partial class Response_Get
    {
        public class Answer_Model
        {
            public int AnswerID { get; set; }
            public TypeQuestion TypeQuestion { get; set; }
            public string Response_Question { get; set; }
            public int QuestionID { get; set; }
        }
    }
}
