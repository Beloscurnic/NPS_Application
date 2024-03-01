using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Lincenses
{
    public partial class List_Lincenses
    {
        public class Query : IRequest<List_View_Model>
        {

        }
    }
}
