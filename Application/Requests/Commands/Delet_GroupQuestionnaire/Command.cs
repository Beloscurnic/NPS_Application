using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Delet
    {
        public class Command : IRequest
        {
            public int ID_GroupQuestionnaire { get; set; }

            public Command(int iD_GroupQuestionnaire)
            {
                ID_GroupQuestionnaire = iD_GroupQuestionnaire;
            }
        }
    }
}
