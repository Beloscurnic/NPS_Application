using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_Question
{
    public partial class Question_Upsert
    {
        public class Command_List : IRequest<List_ViewResponseQuestion>
        {
            public IList<CommandQuestion> Commands { get; set; }= new List<CommandQuestion>(); 
            public int OprostnikID { get; set; }
        }
    }
}
