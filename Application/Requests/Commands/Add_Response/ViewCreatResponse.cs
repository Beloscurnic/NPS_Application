using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Requests.Commands.Add_Response.Response_Add;

namespace Application.Requests.Commands.Add_Response
{
    public partial class Response_Add
    {
        public class ViewCreatResponse
        {
            public int ResponseID { get; set; }
            public DateTime? Data_Creat_Response { get; set; }
            public IList<ViewAnswertResponse>? Answers { get; set; } = new List<ViewAnswertResponse>();
            public int OprostnikID { get; set; }
        }
    }
}