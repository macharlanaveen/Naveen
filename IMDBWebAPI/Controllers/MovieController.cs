using IMDBBAL.Movie;
using IMDBDTOModel.Movie;
using MasterProjectCommonUtility.Logger;
using MasterProjectCommonUtility.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IMovieService _movieService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(ILoggerManager loggerManager, IMovieService movieService, IWebHostEnvironment webHostEnvironment)
        {
            _loggerManager = loggerManager;
            _webHostEnvironment = webHostEnvironment;
            _movieService = movieService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieRequestDTO request_DTO)
        {
            ResultWithDataDTO<int> resultWithDataDTO =
                new ResultWithDataDTO<int> { IsSuccessful = false };

            if (request_DTO == null)
            {
                resultWithDataDTO.IsBusinessError = true;
                resultWithDataDTO.BusinessErrorMessage = "Error,Product Information posted to the Server is empty. Kindly retry, or contact System Admin.";
                return BadRequest(resultWithDataDTO);
            }

            _loggerManager.LogInfo("Entry MovieController=> AddMovie");

            resultWithDataDTO = await _movieService.AddMovie(request_DTO);

            _loggerManager.LogInfo("Exit MovieController=> AddMovie");

            if (resultWithDataDTO.IsSuccessful)
            { return Ok(resultWithDataDTO); }
            else { return BadRequest(resultWithDataDTO); }
            //}
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieRequestDTO request_DTO)
        {
            ResultWithDataDTO<int> resultWithDataDTO =
                new ResultWithDataDTO<int> { IsSuccessful = false };

            if (request_DTO == null)
            {
                resultWithDataDTO.IsBusinessError = true;
                resultWithDataDTO.BusinessErrorMessage = "Error,Product Information posted to the Server is empty. Kindly retry, or contact System Admin.";
                return BadRequest(resultWithDataDTO);
            }

            _loggerManager.LogInfo("Entry MovieController=> UpdateMovie");

            resultWithDataDTO = await _movieService.UpdateMovie(request_DTO);

            _loggerManager.LogInfo("Exit MovieController=> UpdateMovie");

            if (resultWithDataDTO.IsSuccessful)
            { return Ok(resultWithDataDTO); }
            else { return BadRequest(resultWithDataDTO); }
            //}
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetMovie()
        {
            ResultWithDataDTO<List<GetMovieResponseDTO>> resultWithDataDTO =
                new ResultWithDataDTO<List<GetMovieResponseDTO>> { IsSuccessful = false };

            //if (request_DTO == null)
            //{
            //    resultWithDataDTO.IsBusinessError = true;
            //    resultWithDataDTO.BusinessErrorMessage = "Error,Product Information posted to the Server is empty. Kindly retry, or contact System Admin.";
            //    return BadRequest(resultWithDataDTO);
            //}

            _loggerManager.LogInfo("Entry MovieController=> GetMovie");

            resultWithDataDTO = await _movieService.GetMovie();

            _loggerManager.LogInfo("Exit MovieController=> GetMovie");

            if (resultWithDataDTO.IsSuccessful)
            { return Ok(resultWithDataDTO); }
            else { return BadRequest(resultWithDataDTO); }
            //}
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UploadFile([FromQuery] string PathName, List<IFormFile> files)
        {
            var lstPath = new List<string>();
            long size = files.Sum(f => f.Length);
            string uniqueFileName = null;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    _loggerManager.LogError("Function Upload Start");
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", PathName);
                    _loggerManager.LogError("Folder Path" + uploadsFolder);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        lstPath.Add(filePath.Replace(_webHostEnvironment.WebRootPath, ""));
                        await formFile.CopyToAsync(fileStream);
                    }
                    _loggerManager.LogError("Function Upload END");
                }
            }

            return Ok(new { Path = lstPath });
        }
    }
}
