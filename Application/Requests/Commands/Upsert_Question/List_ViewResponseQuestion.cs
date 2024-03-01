using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_Question
{
    public partial class Question_Upsert
    {
        public class List_ViewResponseQuestion
        {
            public IList<ViewResponseQuestion> List_Response { get; set; } = new List<ViewResponseQuestion>();
        }
    }
}
