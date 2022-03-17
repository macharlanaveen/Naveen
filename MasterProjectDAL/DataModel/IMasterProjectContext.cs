using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterProjectDAL.DataModel
{
    public interface IMasterProjectContext: IMasterProjectDbContext
    {
        public DbSet<Product> Product { get; set; }
    }
}
