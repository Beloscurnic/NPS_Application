using Application.Requests.Queries.Get_Answer;
using Microsoft.AspNetCore.Mvc;
using Application.Requests.Commands.Delet_Answert;
namespace NPS_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class AnswertController : BaseController
    {
        [HttpGet("GetAnswert")]
        public async Task<ActionResult<Answer_Get.ViewModelAnswert>> GetAnswert(int answertID)
        {
            var query = new Answer_Get.Query { AnswertID = answertID };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpDelete("Delet_Answert")]
        public async Task<ActionResult> Delet_Answert(int answertID)
        {
            var command = new Answert_Delet.Command { AnswertId = answertID };
            await Mediator.Send(command);    
            return Ok();
        }
    }
}
