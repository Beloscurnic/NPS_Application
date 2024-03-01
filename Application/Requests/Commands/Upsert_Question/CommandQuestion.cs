using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.EnumCore;

namespace Application.Requests.Commands.Upsert_Question
{
    public partial class Question_Upsert
    {
        public class CommandQuestion
        {
            public int? QuestionID { get; set; }
            public int? Key { get; set; }
            public bool Insert_before { get; set; }
            public Status_Question IsDeleted { get; set; }
            public TypeQuestion TypeQuestion { get; set; }
            public string? Name_Question { get; set; }
        //    public IList<ResponseQuestionVariant>? Questions_Variants { get; set; }
        }
    }
}
