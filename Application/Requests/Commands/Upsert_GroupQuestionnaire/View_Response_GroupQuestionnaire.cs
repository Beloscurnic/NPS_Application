using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Add
    {
        public class View_Response_GroupQuestionnaire
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int? CompanyOID { get; set; }
           // public Oprostnik? Oprostnik { get; set; }
            public Guid? LincenseID { get; set; }
            public View_Response_GroupQuestionnaire (int id, string name, int? companyoid, Guid? license)
            {
                ID = id;
                Name = name;
                CompanyOID = companyoid;
                LincenseID = license;
            }
        }
    }
}
