using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_OprostnikOne
{
    public partial class Oprostnik_GetOne
    {
        public class Query_Oprostnik : IRequest<ViewModelOprostnik>
        {
            public int ID { get; set; }
            public Query_Oprostnik(int iD)
            {
                ID = iD;
            }   
        }
    }
}
