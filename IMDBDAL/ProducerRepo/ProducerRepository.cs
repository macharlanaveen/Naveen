using MasterProjectCommonUtility.Logger;
using MasterProjectDAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDBDAL.ProducerRepo
{
    public class ProducerRepository : IProducerRepository
    {
        private InaveendbContext _masterProjectContext;
        private ILoggerManager _loggerManager;


        public ProducerRepository(InaveendbContext masterProjectContext, ILoggerManager loggerManager)
        {
            _masterProjectContext = masterProjectContext;
            _loggerManager = loggerManager;
        }
        public async Task<int> AddProducer(DataModel.Producer Producer)
        {
            _loggerManager.LogInfo("Entry ProducerRepository=> AddProducer");
            await _masterProjectContext.Producer.AddAsync(Producer);
            await _masterProjectContext.SaveChangesAsync();
            _loggerManager.LogInfo("Exit ProducerRepository=> AddProducer");
            return 1;
        }
    }
}
