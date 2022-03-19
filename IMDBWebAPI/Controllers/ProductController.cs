using MasterProjectBAL.Product;
using MasterProjectCommonUtility.Logger;
using MasterProjectCommonUtility.Response;
using MasterProjectDTOModel.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILoggerManager _loggerManager;

        private readonly IProductService _productService;

        public ProductController(ILoggerManager loggerManager, IProductService productService)
        {
            _loggerManager = loggerManager;

            _productService = productService;
        }

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> AddProduct([FromBody]ProductRequest_DTO request_DTO)
        //{
        //    ResultWithDataDTO<ProductResponse_DTO> resultWithDataDTO =
        //        new ResultWithDataDTO<ProductResponse_DTO> { IsSuccessful = false };

        //    if (request_DTO == null)
        //    {
        //        resultWithDataDTO.IsBusinessError = true;
        //        resultWithDataDTO.BusinessErrorMessage = "Error,Product Information posted to the Server is empty. Kindly retry, or contact System Admin.";
        //        return BadRequest(resultWithDataDTO);
        //    }
            
        //    _loggerManager.LogInfo("Entry ProductController=> AddProduct");
            
        //    resultWithDataDTO = await _productService.AddProduct(request_DTO);
            
        //    _loggerManager.LogInfo("Exit ProductController=> AddProduct");
            
        //    if (resultWithDataDTO.IsSuccessful)
        //    { return Ok(resultWithDataDTO); }
        //    else { return BadRequest(resultWithDataDTO); }
        //}

    }
}
