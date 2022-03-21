using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDTOModel.Movie
{
    public class UpdateMovieRequestDTO
    {
        public UpdateMovieRequestDTO()
        {
            updateMovieRequest = new UpdateMovieRequest();
        }
        public UpdateMovieRequest updateMovieRequest { get; set; }
        public class UpdateMovieRequest
        {
            public int IdMovie { get; set; }
            public string Plot { get; set; }
            public DateTime? DateOfRelease { get; set; }
            public string Poster { get; set; }
            public int? ProducerId { get; set; }
            public List<int> ActorId { get; set; }
        }
    }
}
