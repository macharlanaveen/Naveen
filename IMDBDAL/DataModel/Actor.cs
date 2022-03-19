using System;
using System.Collections.Generic;

namespace IMDBDAL.DataModel
{
    public partial class Actor
    {
        public Actor()
        {
            Movie = new HashSet<Movie>();
        }

        public int IdActor { get; set; }
        public string ActorName { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
