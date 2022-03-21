using AutoMapper;
using IMDBDAL.MovieRepo;
using IMDBDTOModel.Movie;
using MasterProjectCommonUtility.Logger;
using MasterProjectCommonUtility.Response;
using MasterProjectDAL.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBBAL.Movie
{
    public class MovieService : IMovieService
    {
        readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private InaveendbContext _masterProjectContext;
        private readonly IMovieRepository _movieRepository;
        public MovieService(ILoggerManager loggerManager, IMapper mapper, IMovieRepository movieRepository, InaveendbContext masterProjectContext)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _movieRepository = movieRepository;
            _masterProjectContext = masterProjectContext;
        }
        public async Task<ResultWithDataDTO<int>> AddMovie(AddMovieRequestDTO request_DTO)
        {
            _loggerManager.LogInfo("Entry MovieService=> AddMovie");
            ResultWithDataDTO<int> resultWithDataBO = new ResultWithDataDTO<int>
            {
                IsSuccessful = false
            };
            try
            {
                List<IMDBDAL.DataModel.Actorhasmovie> ActroMovieList = new List<IMDBDAL.DataModel.Actorhasmovie>();
                var dataResult = await _movieRepository.AddMovie(_mapper.Map<IMDBDAL.DataModel.Movie>(request_DTO.movieRequest));

                if (dataResult != null)
                {
                    (from list in request_DTO.ActorId
                     select list).ToList().ForEach((list) =>
                     {
                         IMDBDAL.DataModel.Actorhasmovie ActorMovie = new IMDBDAL.DataModel.Actorhasmovie();
                         ActorMovie.IdMovie = dataResult.IdMovie;
                         ActorMovie.IdActor = list;
                         if (ActorMovie.IdActor != 0)
                         {
                             ActroMovieList.Add(ActorMovie);
                         }
                     });
                    if (ActroMovieList.Count > 0)
                    {
                        var response = await _movieRepository.AddActorhasmovie(ActroMovieList);
                        if (response != 0)
                        {
                            resultWithDataBO.Data = _mapper.Map<int>(response);
                            resultWithDataBO.IsSuccessful = true;
                            resultWithDataBO.Message = $"Movie data Saved Successfully.";
                            _loggerManager.LogInfo(resultWithDataBO.Message);
                        }
                    }
                    else
                    {
                        resultWithDataBO.Data = 0;
                        resultWithDataBO.IsBusinessError = true;
                        resultWithDataBO.Message = $"ActroMovie Data Not Found.";
                        _loggerManager.LogInfo(resultWithDataBO.Message);
                    }
                }
                else
                {
                    resultWithDataBO.IsBusinessError = true;
                    resultWithDataBO.BusinessErrorMessage = $"Failed to Save Movie Data'.\nKindly retry or contact System Administrator.";
                    _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
                }

            }
            catch (Exception ex)
            {
                resultWithDataBO.IsBusinessError = true;
                resultWithDataBO.BusinessErrorMessage = $"Failed to add Movie Detail-Error observed during MovieName: '{request_DTO.movieRequest.Poster }''.\nKindly retry or contact System Administrator.";
                resultWithDataBO.SystemErrorMessage = $"MovieService => AddMovie: Exception Message: {ex.Message}\n" +
                    $"Stack Trace: {ex.StackTrace}.\n Inner Exception Message:{ex.InnerException?.Message}";
                _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
            }
            return resultWithDataBO;
        }
        public async Task<ResultWithDataDTO<int>> UpdateMovie(UpdateMovieRequestDTO request_DTO)
        {
            _loggerManager.LogInfo("Entry MovieService=> UpdateMovie");
            ResultWithDataDTO<int> resultWithDataBO = new ResultWithDataDTO<int>
            {
                IsSuccessful = false
            };
            try
            {
                var Existdata = await _movieRepository.GetMovieById(request_DTO.updateMovieRequest.IdMovie);
                if (Existdata != null)
                {
                    var dataResult = await _movieRepository.UpdateMovie(_mapper.Map(request_DTO.updateMovieRequest, Existdata));

                    if (dataResult != 0)
                    {
                        var Listdata = await _movieRepository.GetActorhasmovieById(request_DTO.updateMovieRequest.IdMovie);
                        if(Listdata.Count > 0)
                        {
                            var deleteData = await _movieRepository.RemoveActorhasmovie(Listdata);
                            if(deleteData != 0)
                            {
                                List<IMDBDAL.DataModel.Actorhasmovie> ActroMovieList = new List<IMDBDAL.DataModel.Actorhasmovie>();
                                (from list in request_DTO.updateMovieRequest.ActorId
                                 select list).ToList().ForEach((list) =>
                                 {
                                     IMDBDAL.DataModel.Actorhasmovie ActorMovie = new IMDBDAL.DataModel.Actorhasmovie();
                                     ActorMovie.IdMovie = Existdata.IdMovie;
                                     ActorMovie.IdActor = list;
                                     if (ActorMovie.IdActor != 0)
                                     {
                                         ActroMovieList.Add(ActorMovie);
                                     }
                                 });
                                var response = await _movieRepository.AddActorhasmovie(ActroMovieList);
                            }
                        }
                        else
                        {
                            
                        }
                        resultWithDataBO.Data = _mapper.Map<int>(dataResult);
                        resultWithDataBO.IsSuccessful = true;
                        resultWithDataBO.Message = $"MovieId ; {request_DTO.updateMovieRequest.IdMovie} from Movie Updated Successfully.";
                        _loggerManager.LogInfo(resultWithDataBO.Message);
                    }
                    else
                    {
                        resultWithDataBO.IsBusinessError = true;
                        resultWithDataBO.BusinessErrorMessage = $"Failed to Save Update Data'.\nKindly retry or contact System Administrator.";
                        _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
                    }
                }
                else
                {
                    resultWithDataBO.IsBusinessError = true;
                    resultWithDataBO.BusinessErrorMessage = $"MovieId : {request_DTO.updateMovieRequest.IdMovie} from Movie Not Found'.\nKindly retry or contact System Administrator.";
                    _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
                }

            }
            catch (Exception ex)
            {
                resultWithDataBO.IsBusinessError = true;
                resultWithDataBO.BusinessErrorMessage = $"Failed to add Movie Detail-Error observed during Plot: '{request_DTO.updateMovieRequest.Plot }''.\nKindly retry or contact System Administrator.";
                resultWithDataBO.SystemErrorMessage = $"MovieService => UpdateMovie: Exception Message: {ex.Message}\n" +
                    $"Stack Trace: {ex.StackTrace}.\n Inner Exception Message:{ex.InnerException?.Message}";
                _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
            }
            return resultWithDataBO;
        }
        public async Task<ResultWithDataDTO<List<GetMovieResponseDTO>>> GetMovie()
        {
            _loggerManager.LogInfo("Entry MovieService=> GetMovie");
            ResultWithDataDTO<List<GetMovieResponseDTO>> resultWithDataBO = new ResultWithDataDTO<List<GetMovieResponseDTO>>
            {
                IsSuccessful = false
            };
            try
            {
                var dataResult = await _movieRepository.GetMovie();

                if (dataResult != null)
                {
                    resultWithDataBO.Data = _mapper.Map<List<GetMovieResponseDTO>>(dataResult);
                    resultWithDataBO.IsSuccessful = true;
                    resultWithDataBO.Message = $"Movie Data Retrived Successfully.";
                    _loggerManager.LogInfo(resultWithDataBO.Message);
                }
                else
                {
                    resultWithDataBO.IsBusinessError = true;
                    resultWithDataBO.BusinessErrorMessage = $"Failed to Save Movie Data'.\nKindly retry or contact System Administrator.";
                    _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
                }

            }
            catch (Exception ex)
            {
                resultWithDataBO.IsBusinessError = true;
                resultWithDataBO.BusinessErrorMessage = $"Failed to add Movie Detail-Error observed during Movie:.\nKindly retry or contact System Administrator.";
                resultWithDataBO.SystemErrorMessage = $"MovieService => GetMovie: Exception Message: {ex.Message}\n" +
                    $"Stack Trace: {ex.StackTrace}.\n Inner Exception Message:{ex.InnerException?.Message}";
                _loggerManager.LogError(resultWithDataBO.BusinessErrorMessage);
            }
            return resultWithDataBO;
        }
    }
}
