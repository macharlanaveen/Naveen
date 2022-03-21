using IMDBDTOModel.Actor;
using MasterProjectCommonUtility.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDBBAL.Actor
{
    public interface IActorService
    {
        Task<ResultWithDataDTO<int>> AddActor(AddActorRequestDTO request_DTO);
    }
}
