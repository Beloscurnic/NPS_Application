using Application.Requests.Commands.Delet_QuestionVariant;
using Application.Requests.Commands.Update_Status_QuestionVariant;
using Application.Requests.Commands.Upsert_QuestionVariant;
using Application.Requests.Queries.Get_List_QuestionVariant;
using Application.Requests.Queries.Get_QuestionVariant;
using Microsoft.AspNetCore.Mvc;
using NPS_WebAPI.Model.Upsert_QuestionVariant;

namespace NPS_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class QuestionVariantController : BaseController
    {
        [HttpGet("GetListQuestionVariant")]
        public async Task<ActionResult<QuestionVariant_Get_List.List_ViewModelQuestionVariant>> GetListQuestionVariant(int QuestionID)
        {
            var query = new QuestionVariant_Get_List.Query { QuestionID = QuestionID };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("GetQuestionVariant")]
        public async Task<ActionResult<QuestionVariant_Get.ViewModelQuestionVariant>> GetQuestionVariant(int QuestionVariant_ID)
        {
            var query = new QuestionVariant_Get.Query { QuestionVariant_ID = QuestionVariant_ID };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut("UpdateStatusQuestionVariant")]
        public async Task<ActionResult> UpdateStatusQuestionVariant(int QuestionVariant_ID, int oprostnikid)
        {
            var command = new QuestionVariant_Status_Update.Command { QuestionVariant_ID = QuestionVariant_ID, Oprostnik_ID = oprostnikid };
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("UpsertQuestionVariantetest")]
        public async Task<ActionResult<QuestionVaraint_Upsert.ListViewResponseQuestionVariant>> UpsertQuestionVariante([FromBody] UpsertListQuestionVariant_DTO upsert_List_QuestionVariant_DTO)
        {
            var command = new QuestionVaraint_Upsert.CommandListQuestionVariant
            { QuestionVariant_Commands = upsert_List_QuestionVariant_DTO.UpsertVariantQuestions, QuestionID = upsert_List_QuestionVariant_DTO.QuestionID, OprostnikID = upsert_List_QuestionVariant_DTO.OprostnikID};
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpDelete("Delet_QuestionVariant")]
        public async Task<ActionResult> Delet_QuestionVariant(int QuestionVariantID, int oprostnikID)
        {
            var commmand = new QuestionVariant_Delet.Command
            {
                QuestionVariantID = QuestionVariantID,
                OprostnikID = oprostnikID
            };
            await Mediator.Send(commmand);
            return Ok();
        }
    }
}
