using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDBDAL.ActorRepo
{
    public interface IActorRepository
    {
        Task<int> AddActor(DataModel.Actor Actor);
    }
}
