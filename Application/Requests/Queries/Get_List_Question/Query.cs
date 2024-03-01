using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Question
{
    public partial class List_Question_Get
    {
        public class Query: IRequest<List_View_Model_Question>
        {
            public int OprostnikID { get; set; }

        }
    }
}
