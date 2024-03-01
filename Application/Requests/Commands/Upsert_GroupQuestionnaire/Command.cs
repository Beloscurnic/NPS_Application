using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Add
    {
        public class Command: IRequest<View_Response_GroupQuestionnaire>
        {
            public int? GroupQuestionnaireID { get; set; }
            public string Name { get; set; }
         
            public Guid? LincenseID { get; set; }
 
            public Command (int? groupQuestionnaireID, string name, Guid? licenseid)
            {
                GroupQuestionnaireID = groupQuestionnaireID;
                Name = name;
                LincenseID = licenseid;
            }
        }
    }
}
