using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Statisticka
{
    public partial class ListStatistickaGet
    {
        public class ViewModelList_Statistica
        {         
            public IDictionary<int, QuestionInfo>? Questions_Variants { get; set; }
        }
    }
}