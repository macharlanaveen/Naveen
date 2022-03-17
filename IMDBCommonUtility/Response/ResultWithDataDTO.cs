using System;
using System.Collections.Generic;
using System.Text;

namespace MasterProjectCommonUtility.Response
{
    public class ResultWithDataDTO<T> : ResultDTO
    {
        public T Data { get; set; }
    }
}
