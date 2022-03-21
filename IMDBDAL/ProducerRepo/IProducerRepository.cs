using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDBDAL.ProducerRepo
{
    public interface IProducerRepository
    {
        Task<int> AddProducer(DataModel.Producer Producer);
    }
}
