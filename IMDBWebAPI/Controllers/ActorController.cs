using IMDBBAL.Actor;
using IMDBDTOModel.Actor;
using MasterProjectCommonUtility.Logger;
using MasterProjectCommonUtility.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IActorService _actorService;

        public ActorController(ILoggerManager loggerManager, IActorService actorService)
        {
            _loggerManager = loggerManager;
            _actorService = actorService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddActor([FromBody] AddActorRequestDTO request_DTO)
        {
            ResultWithDataDTO<int> resultWithDataDTO =
                new ResultWithDataDTO<int> { IsSuccessful = false };

            if (request_DTO == null)
            {
                resultWithDataDTO.IsBusinessError = true;
                resultWithDataDTO.BusinessErrorMessage = "Error,Product Information posted to the Server is empty. Kindly retry, or contact System Admin.";
                return BadRequest(resultWithDataDTO);
            }

            _loggerManager.LogInfo("Entry ActorController=> AddActor");

            resultWithDataDTO = await _actorService.AddActor(request_DTO);

            _loggerManager.LogInfo("Exit ActorController=> AddActor");

            if (resultWithDataDTO.IsSuccessful)
            { return Ok(resultWithDataDTO); }
            else { return BadRequest(resultWithDataDTO); }
        }
    }
}
