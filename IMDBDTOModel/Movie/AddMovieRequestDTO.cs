using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDTOModel.Movie
{
    public class AddMovieRequestDTO
    {
        public AddMovieRequestDTO()
        {
            movieRequest = new MovieRequest();
        }
        public MovieRequest movieRequest { get; set; }
        public List<int> ActorId { get; set; }
        public class MovieRequest
        {
            public string Plot { get; set; }
            public DateTime? DateOfRelease { get; set; }
            public string Poster { get; set; }
            public int? ProducerId { get; set; }
        }
    }
}
