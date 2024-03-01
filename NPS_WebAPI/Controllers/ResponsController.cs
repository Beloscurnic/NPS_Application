using Application.Requests.Commands.Add_Response;
using Application.Requests.Queries.Get_List_Response;
using Application.Requests.Queries.Get_Response;
using Application.Requests.Commands.Delet_Response;
using Microsoft.AspNetCore.Mvc;
using NPS_WebAPI.Model;

namespace NPS_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class ResponsController : BaseController
    {
        [HttpGet("GetListResponse")]
        public async Task<ActionResult<List_Response_Get.List_View_Model_Response>> GetListResponse(int OprostnikID)
        {
            var query = new List_Response_Get.Query { OprostnikID = OprostnikID };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("GetResponse")]
        public async Task<ActionResult<Response_Get.ViewModelResponse>> GetResponse(int Response_ID)
        {
            var query = new Response_Get.Query { Response_ID = Response_ID };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost("Add_Response")]
        public async Task<ActionResult<Response_Add.ViewCreatResponse>> Add_Response([FromBody] Creat_Respons_DTO creat_Respons_DTO)
        {
            var command = new Response_Add.Command
            {
                Answers = creat_Respons_DTO.Answers,
                OprostnikID = creat_Respons_DTO.OprostnikID
            };
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }
        [HttpDelete("Delit_Response")]
        public async Task<ActionResult> Delit_Response(int Response_ID)
        {
            var command = new Response_Delit.Command { Response_ID = Response_ID };
            await Mediator.Send(command);
            return Ok();
        }


    }
}
