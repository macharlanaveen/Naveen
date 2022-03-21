using IMDBBAL.Producer;
using IMDBDTOModel.Producer;
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
    public class ProducerController : ControllerBase
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IProducerService _producerService;

        public ProducerController(ILoggerManager loggerManager, IProducerService producerService)
        {
            _loggerManager = loggerManager;
            _producerService = producerService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddProducer([FromBody] AddProducerRequestDTO request_DTO)
        {
            ResultWithDataDTO<int> resultWithDataDTO =
                new ResultWithDataDTO<int> { IsSuccessful = false };

            if (request_DTO == null)
            {
                resultWithDataDTO.IsBusinessError = true;
                resultWithDataDTO.BusinessErrorMessage = "Error,Product Information posted to the Server is empty. Kindly retry, or contact System Admin.";
                return BadRequest(resultWithDataDTO);
            }

            _loggerManager.LogInfo("Entry ProducerController=> AddProducer");

            resultWithDataDTO = await _producerService.AddProducer(request_DTO);

            _loggerManager.LogInfo("Exit ProducerController=> AddProducer");

            if (resultWithDataDTO.IsSuccessful)
            { return Ok(resultWithDataDTO); }
            else { return BadRequest(resultWithDataDTO); }
        }
    }
}
