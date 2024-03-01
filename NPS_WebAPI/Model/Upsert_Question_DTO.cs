using Domain;
using Application.Requests.Commands.Upsert_Question;
using static Domain.EnumCore;

namespace NPS_WebAPI.Model
{
    public class Upsert_Question_DTO
    {
        public IList<Question_Upsert.CommandQuestion> UpsertQuestions { get; set; }
        public int OprostnikID { get; set; }
    }
}
