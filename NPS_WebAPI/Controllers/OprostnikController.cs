using Application.Requests.Queries.Get_Check_Version_Oprostnik;
using Application.Requests.Queries.Get_Statisticka;
using Microsoft.AspNetCore.Mvc;
using NPS_WebAPI.Model;

namespace NPS_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class OprostnikController : BaseController
    {
        [HttpGet("Get_List_Oprostnik")]
        public async Task<ActionResult<Application.Requests.Queries.Get_List_Oprostnik.List_Oprostnik_Get.List_View_Model_Oprostnik>> Get_List_Oprostnik()
        {
            var query = new Application.Requests.Queries.Get_List_Oprostnik.List_Oprostnik_Get.Query();
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("Get_Oprostnik")]
        public async Task<ActionResult<Application.Requests.Queries.Get_OprostnikOne.Oprostnik_GetOne.ViewModelOprostnik>> GetOprostnik(int ID_Oprostnik)
        {
            var query = new Application.Requests.Queries.Get_OprostnikOne.Oprostnik_GetOne.Query_Oprostnik(ID_Oprostnik);
            var rm = await Mediator.Send(query);
            return Ok(rm);
        }

        [HttpPost("Upsert_Oprostnik")]
        public async Task<ActionResult<Application.Requests.Commands.Upsert_Oprostnik.OprostnikUpsert.View_Response_Oprostn>> Upsert_Oprostnik([FromBody] Creat_Oprostnik_DTO creat_Creat_Oprostnik_DTO)
        {
            var command = new Application.Requests.Commands.Upsert_Oprostnik.OprostnikUpsert.Command
            {
                DateRedaction = creat_Creat_Oprostnik_DTO.DateRedaction,
                GroupQuestionnaireID = creat_Creat_Oprostnik_DTO.GroupQuestionnaireID,
                OprostnikID = creat_Creat_Oprostnik_DTO.OprostnikID,
            };
            var rm = await Mediator.Send(command);
            return Ok(rm);
        }
        [HttpDelete("Delet_Oprostnik")]
        public async Task<ActionResult> Delet_Oprostnik(int ID_Oprostniks)
        {
            var command = new Application.Requests.Commands.Delet_Oprostnik.Oprostnik_Delet.Command { ID_Oprostniks = ID_Oprostniks };
            await Mediator.Send(command);
            return Ok();
        }
        [HttpGet("Check_Version_Oprostnik")]
        public async Task<ActionResult<bool>> Check_Version_Oprostnik(int OprostnikId, DateTime Data_Use_Oprosnik)
        {
            var query = new Check_Version_Oprostnik_Get.Query
            {
                OprostnikId = OprostnikId,
                Data_Used = Data_Use_Oprosnik
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Creat_Statistika")]
        public async Task<ActionResult<Statisticka_Get.View_Model_Statistica>> Creat_Statistika(int idOprosnika, int QuestionID, DateTime? data_Start, DateTime? data_End)
        {

            var query = new Statisticka_Get.Query { Oprostnik_ID = idOprosnika, QuestionID = QuestionID, Data_End = data_End, Data_Start = data_Start };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("CreatListStatistika")]
        public async Task<ActionResult<Application.Requests.Queries.Get_List_Statisticka.ListStatistickaGet.ViewModelList_Statistica>> CreatListStatistika(int idOprosnika, DateTime? data_Start, DateTime? data_End)
        {

            var query = new Application.Requests.Queries.Get_List_Statisticka.ListStatistickaGet.Query { Oprostnik_ID = idOprosnika, Data_End = data_End, Data_Start = data_Start };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
