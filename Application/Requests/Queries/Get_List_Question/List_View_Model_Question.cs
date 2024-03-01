using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Question
{
    public partial class List_Question_Get
    {
        public class List_View_Model_Question
        {
            public IList<View_Model_Question> View_List_Model_Question { get; set; }
        }
    }
}
