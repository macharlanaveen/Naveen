using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDTOModel.Actor
{
    public class AddActorRequestDTO
    {
        public string Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
