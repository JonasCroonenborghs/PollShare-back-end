using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollShareBackEnd.Models
{
    public class PollGebruiker
    {
        public long pollGebruikerID { get; set; }
        public long pollID { get; set; }
        public long gebruikerID { get; set; }
    }
}
