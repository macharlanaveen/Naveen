using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDTOModel.Producer
{
    public class ADDProducerRequestDTO
    {
        public string Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string Gender { get; set; }
    }
}
