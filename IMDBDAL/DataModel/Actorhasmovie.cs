using System;
using System.Collections.Generic;

namespace IMDBDAL.DataModel
{
    public partial class Actorhasmovie
    {
        public int IdActor { get; set; }
        public int IdMovie { get; set; }

        public virtual Actor IdActorNavigation { get; set; }
        public virtual Movie IdMovieNavigation { get; set; }
    }
}
