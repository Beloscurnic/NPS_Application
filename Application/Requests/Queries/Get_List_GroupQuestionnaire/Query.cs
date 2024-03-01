using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_GroupQuestionnaire
{
    public partial class Get_List_GrupQuestion
    {
        public class Query:IRequest<View_Model_List>
        {

        }
    }
}
