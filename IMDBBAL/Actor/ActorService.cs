using AutoMapper;
using IMDBDAL.ActorRepo;
using IMDBDTOModel.Actor;
using MasterProjectCommonUtility.Logger;
using MasterProjectCommonUtility.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDBBAL.Actor
{
    public class ActorService : IActorService
    {
        readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private readonly IActorRepository _actorRepository;
        public ActorService(ILoggerManager loggerManager, IMapper mapper, IActorRepository actorRepository)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _actorRepository = actorRepository;
        }
        public async Task<ResultWithDataDTO<int>> AddActor(AddActorRequestDTO request_DTO)
        {
            _loggerManager.LogInfo("Entry ActorService=> AddActor");
            ResultWithDataDTO<int> resultWithDataBO = new ResultWithDataDTO<int>
            {
                IsSuccessful = false
            };
            try
            {
                var dataResult = await _actorRepository.AddActor(_mapper.Map<IMDBDAL.DataModel.Actor>(request_DTO));

                if (dataResult != 0)
                {
                    resultWithDataBO.Data = _mapper.Map<int>(dataResult);
                    resultWithDataBO.IsSuccessful = true;
                    resultWithDataBO.Message = $"Actor Data Saved Successfully.";
                    _loggerManager.LogInfo(resultWithDataBO.Message);
                }
                else
                {
                    resultWithDataBO.IsBusinessError = true;
                    resultWithDataBO.BusinessErrorMessage = $"Failed to Save Actor Data'.\nKindly retry or contact System Administrator.";
                    _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
                }

            }
            catch (Exception ex)
            {
                resultWithDataBO.IsBusinessError = true;
                resultWithDataBO.BusinessErrorMessage = $"Failed to add Actor Detail-Error observed during Bio: '{request_DTO.Bio }''.\nKindly retry or contact System Administrator.";
                resultWithDataBO.SystemErrorMessage = $"ActorService => AddActor: Exception Message: {ex.Message}\n" +
                    $"Stack Trace: {ex.StackTrace}.\n Inner Exception Message:{ex.InnerException?.Message}";
                _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
            }
            return resultWithDataBO;
        }
    }
}
