using System;
using System.Collections.Generic;

namespace IMDBDAL.DataModel
{
    public partial class Actor
    {
        public Actor()
        {
            Actorhasmovie = new HashSet<Actorhasmovie>();
        }

        public int ActorId { get; set; }
        public string Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Actorhasmovie> Actorhasmovie { get; set; }
    }
}
