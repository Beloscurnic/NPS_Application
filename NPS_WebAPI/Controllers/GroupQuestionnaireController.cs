using Microsoft.AspNetCore.Mvc;
using Application.Requests.Queries.Get_List_GroupQuestionnaire;
using Application.Requests.Queries.Get_GroupQuestionnaire;
using Application.Requests.Commands.Upsert_GroupQuestionnaire;
using Application.Requests.Commands.Delet_GroupQuestionnaire;
using NPS_WebAPI.Model;

namespace NPS_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class GroupQuestionnaireController : BaseController
    {

        [HttpGet("Get_List_GroupQuestionnaire")]
        public async Task<ActionResult<Get_List_GrupQuestion.View_Model_List>> Get_List_GroupQuestionnaire()
        {
            var query = new Get_List_GrupQuestion.Query();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Get_GroupQuestionnaire")]
        public async Task<ActionResult<GroupQuestionnaire_Get.View_Model_GroupQuestionnaire>> Get_GroupQuestionnaire(Guid ID_lincense)
        {
            var query = new GroupQuestionnaire_Get.Query(ID_lincense);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("Creat_GroupQuestionnaire")]
        public async Task<ActionResult<GroupQuestionnaire_Add.View_Response_GroupQuestionnaire>> Creat_GroupQuestionnaire([FromBody] Creat_GroupQuestionnaire_DTO creat_GroupQuestionnaire_DTO)
        {
            var command = new GroupQuestionnaire_Add.Command(creat_GroupQuestionnaire_DTO.Id_GroupQuestionnaire , creat_GroupQuestionnaire_DTO.Name, creat_GroupQuestionnaire_DTO.LincenseID );
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("Delet_GroupQuestionnaire")]
        public async Task<ActionResult> Delet_GroupQuestionnaire([FromBody] int ID_GroupQuestionnaire)
        {
            var command = new GroupQuestionnaire_Delet.Command(ID_GroupQuestionnaire);
            await Mediator.Send(command);
            return Ok();
        }
    }
}
