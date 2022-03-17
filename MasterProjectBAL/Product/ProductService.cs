using AutoMapper;
using MasterProjectCommonUtility.Logger;
using MasterProjectCommonUtility.Response;
using MasterProjectDTOModel.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MasterProjectDAL.DataModel;
using MasterProjectDAL.Product;

namespace MasterProjectBAL.Product
{
    public class ProductService : IProductService
    {
        readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductService(ILoggerManager loggerManager, IMapper mapper, IProductRepository productRepository)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _productRepository = productRepository;
        }


        public async Task<ResultWithDataDTO<ProductResponse_DTO>> AddProduct(ProductRequest_DTO request_DTO)
        {
            _loggerManager.LogInfo("Entry ProductService=> AddContactUs");
            ResultWithDataDTO<ProductResponse_DTO> resultWithDataBO = new ResultWithDataDTO<ProductResponse_DTO>
            {
                IsSuccessful = false
            };
            try
            {
                var dataResult = await _productRepository.AddProduct(_mapper.Map<MasterProjectDAL.DataModel.Product>(request_DTO));

                if (dataResult != null)
                {
                    resultWithDataBO.Data = _mapper.Map<ProductResponse_DTO>(dataResult);
                    resultWithDataBO.IsSuccessful = true;
                    resultWithDataBO.Message = $"Product Save Successfully.";
                    _loggerManager.LogInfo(resultWithDataBO.Message);
                }
                else
                {
                    resultWithDataBO.IsBusinessError = true;
                    resultWithDataBO.BusinessErrorMessage = $"Failed to Save Product Data'.\nKindly retry or contact System Administrator.";
                    _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
                }

            }
            catch (Exception ex)
            {
                resultWithDataBO.IsBusinessError = true;
                resultWithDataBO.BusinessErrorMessage = $"Failed to add Product Detail-Error observed during Product Name: '{request_DTO.ProductName }''.\nKindly retry or contact System Administrator.";
                resultWithDataBO.SystemErrorMessage = $"ProductService => AddProduct: Exception Message: {ex.Message}\n" +
                    $"Stack Trace: {ex.StackTrace}.\n Inner Exception Message:{ex.InnerException?.Message}";
                _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
            }
            return resultWithDataBO;
        }
    }
}
