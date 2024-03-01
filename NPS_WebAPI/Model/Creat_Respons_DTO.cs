
using static Application.Requests.Commands.Add_Response.Response_Add;
using static Domain.EnumCore;

namespace NPS_WebAPI.Model
{
    public class Creat_Respons_DTO
    {
        public IList<CommandAnswert>? Answers { get; set; }
        public int OprostnikID { get; set; }
    }
}
