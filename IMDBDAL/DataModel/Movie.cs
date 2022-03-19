using System;
using System.Collections.Generic;

namespace IMDBDAL.DataModel
{
    public partial class Movie
    {
        public int IdMovie { get; set; }
        public string MovieName { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public int? ProducerId { get; set; }
        public int? ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
