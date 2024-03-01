using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.EnumCore;

namespace Application.Requests.Commands.Add_Response
{
    public partial class Response_Add
    {
        public class CommandAnswert
        {
            public List<int> Response_Question_ID { get; set; }
            public int QuestionID { get; set; }
          //  public TypeQuestion TypeQuestion { get; set; }
        }
    }
}
