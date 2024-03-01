using Application.Requests.Commands.Delet_Question;
using Application.Requests.Commands.Update_Status_Question;
using Application.Requests.Commands.Upsert_Question;
using Application.Requests.Queries.Get_List_Question;
using Application.Requests.Queries.Get_Question;
using Microsoft.AspNetCore.Mvc;
using NPS_WebAPI.Model;

namespace NPS_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class QuestionController : BaseController
    {
        [HttpGet("GetListQuestion")]
        public async Task<ActionResult<List_Question_Get.List_View_Model_Question>> GetListQuestion(int OprostnikID)
        {
            var query = new List_Question_Get.Query { OprostnikID = OprostnikID };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("GetQustion")]
        public async Task<ActionResult<Question_Get.ViewModelQuestion>> GetQustion(int Question_ID)
        {
            var query = new Question_Get.Query { Question_ID = Question_ID };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost("UpsertQuestion")]
        public async Task<ActionResult<Question_Upsert.ViewResponseQuestion>> UpsertQuestion([FromBody] Upsert_Question_DTO upsert_Question_DTO)
        {
            var command = new Question_Upsert.Command_List
            {
                OprostnikID = upsert_Question_DTO.OprostnikID,
                Commands = upsert_Question_DTO.UpsertQuestions
            };
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }
        [HttpPut("Update_Status_Question")]
        public async Task<ActionResult> Update_Status_Question(int QuestionID)
        {
            var command = new Status_Question_Update.Command { QuestionID = QuestionID };
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("Delet_Question")]
        public async Task<ActionResult> Delet_Question(int Question_ID)
        {
            var command = new Question_Delet.Command
            {
                Question_ID = Question_ID
            };
            await Mediator.Send(command);
            return Ok();
        }
    }
}
