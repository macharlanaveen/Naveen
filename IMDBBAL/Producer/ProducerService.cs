using AutoMapper;
using IMDBDAL.ProducerRepo;
using IMDBDTOModel.Producer;
using MasterProjectCommonUtility.Logger;
using MasterProjectCommonUtility.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDBBAL.Producer
{
    public class ProducerService : IProducerService
    {
        readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private readonly IProducerRepository _producerRepository;
        public ProducerService(ILoggerManager loggerManager, IMapper mapper, IProducerRepository producerRepository)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _producerRepository = producerRepository;
        }
        public async Task<ResultWithDataDTO<int>> AddProducer(ADDProducerRequestDTO request_DTO)
        {
            _loggerManager.LogInfo("Entry ProducerService=> AddProducer");
            ResultWithDataDTO<int> resultWithDataBO = new ResultWithDataDTO<int>
            {
                IsSuccessful = false
            };
            try
            {
                var dataResult = await _producerRepository.AddProducer(_mapper.Map<IMDBDAL.DataModel.Producer>(request_DTO));

                if (dataResult != 0)
                {
                    resultWithDataBO.Data = _mapper.Map<int>(dataResult);
                    resultWithDataBO.IsSuccessful = true;
                    resultWithDataBO.Message = $"Producer Data Saved Successfully.";
                    _loggerManager.LogInfo(resultWithDataBO.Message);
                }
                else
                {
                    resultWithDataBO.IsBusinessError = true;
                    resultWithDataBO.BusinessErrorMessage = $"Failed to Save Producer Data'.\nKindly retry or contact System Administrator.";
                    _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
                }

            }
            catch (Exception ex)
            {
                resultWithDataBO.IsBusinessError = true;
                resultWithDataBO.BusinessErrorMessage = $"Failed to add Producer Detail-Error observed during Bio: '{request_DTO.Bio }''.\nKindly retry or contact System Administrator.";
                resultWithDataBO.SystemErrorMessage = $"ProducerService => AddProducer: Exception Message: {ex.Message}\n" +
                    $"Stack Trace: {ex.StackTrace}.\n Inner Exception Message:{ex.InnerException?.Message}";
                _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
            }
            return resultWithDataBO;
        }
    }
}
