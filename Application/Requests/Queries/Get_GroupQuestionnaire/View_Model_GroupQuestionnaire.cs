using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Get
    {
        public class View_Model_GroupQuestionnaire
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int? CompanyOID { get; set; }
            //  public Oprostnik? Oprostnik { get; set; }
            public Guid? LincenseID { get; set; }

           public View_Model_GroupQuestionnaire(int iD, string name, int? companyOID, Guid? lincenseID)
            {
                ID = iD;
                Name = name;
                CompanyOID = companyOID;
                LincenseID = lincenseID;
            }
        }
    }
}
