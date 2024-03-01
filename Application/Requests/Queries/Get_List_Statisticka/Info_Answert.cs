using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Statisticka
{
    public partial class ListStatistickaGet
    {
        public class Info_Answert
        {
            public int Count { get; set; }
            public string Name_QuestionVariant { get; set; }
        }
    }
}
