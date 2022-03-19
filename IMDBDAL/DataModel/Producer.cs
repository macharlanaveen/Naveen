using System;
using System.Collections.Generic;

namespace IMDBDAL.DataModel
{
    public partial class Producer
    {
        public Producer()
        {
            Movie = new HashSet<Movie>();
        }

        public int IdProducer { get; set; }
        public string ProducerName { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
