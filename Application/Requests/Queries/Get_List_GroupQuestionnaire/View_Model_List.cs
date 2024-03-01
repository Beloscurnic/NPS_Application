using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_GroupQuestionnaire
{
    public partial class Get_List_GrupQuestion
    {
        public class View_Model_List
        {
            public IList<View_Model_GrupQuestionare> _Model_GrupQuestionares { get; set; }

            public View_Model_List (IList<View_Model_GrupQuestionare> model_GrupQuestionares)
            {
                _Model_GrupQuestionares = model_GrupQuestionares;
            }
        }
    }
}
