using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDTOModel.Movie
{
    public class GetMovieResponseDTO
    {
            public int IdMovie { get; set; }
            public string Plot { get; set; }
            public DateTime? DateOfRelease { get; set; }
            public string Poster { get; set; }
            public int? ProducerId { get; set; }
            public string ProducerName { get; set; }
            public List<ActorResponse> actorResponse { get; set; }
        public class ActorResponse
        {
            public int IdActor { get; set; }
            public string ActorName { get; set; }
        }
    }
}
