using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Oprostnik
{
    public partial class List_Oprostnik_Get
    {
        public class List_View_Model_Oprostnik
        {
            public IList<View_Model_Oprostnik> List_View_Models_Oprostnik { get; set; }
        }
    }
}
