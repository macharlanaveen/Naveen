using System;
using System.Collections.Generic;

namespace IMDBDAL.DataModel
{
    public partial class Movie
    {
        public Movie()
        {
            Actorhasmovie = new HashSet<Actorhasmovie>();
        }

        public int IdMovie { get; set; }
        public string Plot { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public string Poster { get; set; }
        public int? ProducerId { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual ICollection<Actorhasmovie> Actorhasmovie { get; set; }
    }
}
