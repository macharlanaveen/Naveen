using IMDBDTOModel.Movie;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDBDAL.MovieRepo
{
    public interface IMovieRepository
    {
        Task<DataModel.Movie> AddMovie(DataModel.Movie Movie);
        Task<int> AddActorhasmovie(List<DataModel.Actorhasmovie> Actorhasmovie);
        Task<int> UpdateMovie(DataModel.Movie Movie);
        Task<int> RemoveActorhasmovie(List<DataModel.Actorhasmovie> Actorhasmovie);
        Task<DataModel.Movie> GetMovieById(int MovieId);
        Task<List<DataModel.Actorhasmovie>> GetActorhasmovieById(int MovieId);
        Task<List<GetMovieResponseDTO>> GetMovie();
    }
}
