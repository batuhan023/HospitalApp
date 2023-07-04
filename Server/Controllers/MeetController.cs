using HospitalApp.Server.Services.ForMeet;
using HospitalApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetController : ControllerBase
    {
        private readonly IMeetService _meetService;
        public MeetController(IMeetService meetService)
        {
            _meetService = meetService;
        }

        [HttpPost("creatMeet"),Authorize]
        public async Task<ActionResult<ServiceResponse<Meet>>> CreateMeet(Meet meet)
        {
            var result = await _meetService.CreateMeet(meet);
            return Ok(result);
        }

        [HttpPut("cancelMeet/{meetId}"),Authorize]
        public async Task<ActionResult<ServiceResponse<Meet>>> CancelMeet([FromRoute]int meetId)
        {
            var result = await _meetService.CancelMeet(meetId);
            return Ok(result);
        }

        [HttpGet,Authorize]
        public async Task<ActionResult<ServiceResponse<List<Meet>>>> GetMyMeet()
        {
            var result = await _meetService.GetMeetById();
            {
                return Ok(result);
            }

        }
    }
}
