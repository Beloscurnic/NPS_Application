using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_GroupQuestionnaire
{
    public partial class Get_List_GrupQuestion
    {
        public class View_Model_GrupQuestionare
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int? CompanyOID { get; set; }
          //  public Oprostnik? Oprostnik { get; set; }
            public Guid? LincenseID { get; set; }

        }
    }
}
