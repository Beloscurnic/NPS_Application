using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_OprostnikOne
{
    public partial class Oprostnik_GetOne
    {
        public class ViewModelOprostnik
        {
            public int OprostnikID { get; set; }
            public DateTime DataCreat_Oprostnik { get; set; }
            public DateTime? DataModified_Oprostnik { get; set; }
            public int? GroupQuestionnaireID { get; set; }
        }
    }
}
