using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Statisticka
{
    public partial class ListStatistickaGet
    {
        public class Query : IRequest<ViewModelList_Statistica>
        {
            public int Oprostnik_ID { get; set; }
            public DateTime? Data_Start { get; set; }
            public DateTime? Data_End { get; set; }
        }
    }
}
