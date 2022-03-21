using MasterProjectCommonUtility.Logger;
using MasterProjectDAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDBDAL.ActorRepo
{
    public class ActorRepository : IActorRepository
    {
        private InaveendbContext _masterProjectContext;
        private ILoggerManager _loggerManager;


        public ActorRepository(InaveendbContext masterProjectContext, ILoggerManager loggerManager)
        {
            _masterProjectContext = masterProjectContext;
            _loggerManager = loggerManager;
        }
        public async Task<int> AddActor(DataModel.Actor Actor)
        {
            _loggerManager.LogInfo("Entry ActorRepository=> AddActor");
            await _masterProjectContext.Actor.AddAsync(Actor);
            await _masterProjectContext.SaveChangesAsync();
            _loggerManager.LogInfo("Exit ActorRepository=> AddActor");
            return 1;
        }
    }
}
