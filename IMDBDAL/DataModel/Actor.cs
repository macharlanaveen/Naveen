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
        public string Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
