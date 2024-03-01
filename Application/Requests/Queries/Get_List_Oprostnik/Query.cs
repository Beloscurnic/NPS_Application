using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Requests.Queries.Get_List_Lincenses.List_Lincenses;

namespace Application.Requests.Queries.Get_List_Oprostnik
{
    public partial class List_Oprostnik_Get
    {
        public class Query : IRequest<List_View_Model_Oprostnik>
        {

        }
    }
}
