using IMDBDTOModel.Movie;
using MasterProjectCommonUtility.Logger;
using MasterProjectDAL.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMDBDTOModel.Movie.GetMovieResponseDTO;

namespace IMDBDAL.MovieRepo
{
    public class MovieRepository : IMovieRepository
    {
        private InaveendbContext _masterProjectContext;
        private ILoggerManager _loggerManager;


        public MovieRepository(InaveendbContext masterProjectContext, ILoggerManager loggerManager)
        {
            _masterProjectContext = masterProjectContext;
            _loggerManager = loggerManager;
        }
        public async Task<DataModel.Movie> AddMovie(DataModel.Movie Movie)
        {
            _loggerManager.LogInfo("Entry MovieRepository=> AddMovie");
            await _masterProjectContext.Movie.AddAsync(Movie);
            await _masterProjectContext.SaveChangesAsync();
            _loggerManager.LogInfo("Exit MovieRepository=> AddMovie");
            return Movie;
        }
        public async Task<int> AddActorhasmovie(List<DataModel.Actorhasmovie> Actorhasmovie)
        {
            _loggerManager.LogInfo("Entry MovieRepository=> AddActorhasmovie");
            await _masterProjectContext.Actorhasmovie.AddRangeAsync(Actorhasmovie);
            await _masterProjectContext.SaveChangesAsync();
            _loggerManager.LogInfo("Exit MovieRepository=> AddActorhasmovie");
            return 1;
        }
        public async Task<int> UpdateMovie(DataModel.Movie Movie)
        {
            _loggerManager.LogInfo("Entry MovieRepository=> UpdateMovie");
            if (Movie != null)
            {
                _masterProjectContext.Movie.Update(Movie);
                await _masterProjectContext.SaveChangesAsync();
            }
            _loggerManager.LogInfo("Exit MovieRepository=> UpdateMovie");
            return 1;
        }
        public async Task<int> RemoveActorhasmovie(List<DataModel.Actorhasmovie> Actorhasmovie)
        {
            _loggerManager.LogInfo("Entry MovieRepository=> RemoveActorhasmovie");
            if (Actorhasmovie != null)
            {
                _masterProjectContext.Actorhasmovie.RemoveRange(Actorhasmovie);
                await _masterProjectContext.SaveChangesAsync();
            }
            _loggerManager.LogInfo("Exit MovieRepository=> RemoveActorhasmovie");
            return 1;
        }
        public async Task<DataModel.Movie> GetMovieById(int MovieId)
        {
            return await _masterProjectContext.Movie.Where(x => x.IdMovie == MovieId).FirstOrDefaultAsync();
        }
        public async Task<List<DataModel.Actorhasmovie>> GetActorhasmovieById(int MovieId)
        {
            return await _masterProjectContext.Actorhasmovie.Where(x => x.IdMovie == MovieId).ToListAsync();
        }
        public async Task<List<GetMovieResponseDTO>> GetMovie()
        {
            List<GetMovieResponseDTO> responseList = new List<GetMovieResponseDTO>();
            var MovieList = await _masterProjectContext.Movie.ToListAsync();
            foreach(var item in MovieList)
            {
                GetMovieResponseDTO Response = new GetMovieResponseDTO();
                Response.IdMovie = item.IdMovie;
                Response.Plot = item.Plot;
                Response.DateOfRelease = item.DateOfRelease;
                Response.Poster = item.Poster;
                Response.ProducerId = item.ProducerId;
                Response.ProducerName = await _masterProjectContext.Producer.Where(x => x.IdProducer == Response.ProducerId).Select(x => x.Bio).FirstOrDefaultAsync();
                var dataResult = from mov in _masterProjectContext.Movie
                                 join AM in _masterProjectContext.Actorhasmovie on item.IdMovie equals AM.IdMovie into a1
                                 from AM in a1.DefaultIfEmpty()
                                 join act in _masterProjectContext.Actor on AM.IdActor equals act.ActorId into a2
                                 from act in a2.DefaultIfEmpty()
                                 select new ActorResponse
                                 {
                                     IdActor = (int)AM.IdActor,
                                     ActorName = act.Bio
                                 };
                Response.actorResponse = dataResult.Distinct().ToList();
                responseList.Add(Response);
            }
            return responseList;
        }
    }
}
