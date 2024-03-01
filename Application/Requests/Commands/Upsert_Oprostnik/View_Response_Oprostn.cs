using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_Oprostnik
{
    public partial class OprostnikUpsert
    {
        public class View_Response_Oprostn
        {
            public int OprostnikID { get; set; }

            public DateTime DataCreat_Oprostnik { get; set; }
            public DateTime? DataModified_Oprostnik { get; set; }
            public int? GroupQuestionnaireID { get; set; }
        }
    }
}
