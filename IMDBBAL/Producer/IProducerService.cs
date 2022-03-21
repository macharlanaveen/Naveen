using IMDBDTOModel.Producer;
using MasterProjectCommonUtility.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDBBAL.Producer
{
    public interface IProducerService
    {
        Task<ResultWithDataDTO<int>> AddProducer(ADDProducerRequestDTO request_DTO);
    }
}
