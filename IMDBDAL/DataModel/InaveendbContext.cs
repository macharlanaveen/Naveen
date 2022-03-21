using IMDBDAL.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterProjectDAL.DataModel
{
    public interface InaveendbContext: InaveendbDbContext
    {
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<Actorhasmovie> Actorhasmovie { get; set; }
    }
}
