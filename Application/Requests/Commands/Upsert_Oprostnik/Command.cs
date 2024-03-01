using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_Oprostnik
{
    public partial class OprostnikUpsert
    {
        public class Command :IRequest<View_Response_Oprostn>
        {
            public int? OprostnikID { get; set; }
            public int? GroupQuestionnaireID { get; set; }
            public DateTime? DateRedaction { get; set; }

        }
    }
}
