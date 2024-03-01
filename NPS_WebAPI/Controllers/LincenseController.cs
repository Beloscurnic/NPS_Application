using MediatR;
using Microsoft.AspNetCore.Mvc;
using NPS_WebAPI.Model;


namespace NPS_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class LincenseController : BaseController
    {

        [HttpGet("Get_List_Lincenses")]
        public async Task<ActionResult<Application.Requests.Queries.Get_List_Lincenses.List_Lincenses.List_View_Model>> Get_List_Lincenses()
        {
            var query = new Application.Requests.Queries.Get_List_Lincenses.List_Lincenses.Query();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Get_Lincense")]
        public async Task<ActionResult<Application.Requests.Queries.Get_Lincense.Lincense.View_Model_Lincense>> Get_Lincense(Guid ID_Lincense)
        {
            var query = new Application.Requests.Queries.Get_Lincense.Lincense.Query(ID_Lincense);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("Creat_Lincense")]
        public async Task<ActionResult<Application.Requests.Commands.Add_Lincense.Creat_Lincense.View_Response>> Creat_Lincense([FromBody] Creat_Lincense_DTO creat_Lincense_DTO )
        {
            var command = new Application.Requests.Commands.Add_Lincense.Creat_Lincense.Command
            (creat_Lincense_DTO.CompanyOID, creat_Lincense_DTO.ActivationCode, creat_Lincense_DTO.Lincense_Activated, creat_Lincense_DTO.License_Status, creat_Lincense_DTO.Device_Name);
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delet_Lincense")]
        public async Task<ActionResult> Delet_Lincense(Guid ID_Lincense)
        {
            var command = new Application.Requests.Commands.Delet_Lincense.Lincense_Delet.Command(ID_Lincense);
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut("Update_Lincense_Status")]
        public async Task<ActionResult> Update_Lincense_Status([FromBody] Update_Lincense_Status update_Lincense_Status)    
        {
            var command = new Application.Requests.Commands.Update_Status_Lincense.Status_Updata.Command(update_Lincense_Status.ID, update_Lincense_Status.LicenseStatus);
            await Mediator.Send(command);
            return Ok();
        }
    }
}
