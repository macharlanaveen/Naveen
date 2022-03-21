using IMDBDTOModel.Movie;
using MasterProjectCommonUtility.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDBBAL.Movie
{
    public interface IMovieService
    {
        Task<ResultWithDataDTO<int>> AddMovie(AddMovieRequestDTO request_DTO);
        Task<ResultWithDataDTO<int>> UpdateMovie(UpdateMovieRequestDTO request_DTO);
        Task<ResultWithDataDTO<List<GetMovieResponseDTO>>> GetMovie();
    }
}
