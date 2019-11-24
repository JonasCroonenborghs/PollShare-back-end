using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollShareBackEnd.Models
{
    public class Antwoord
    {
        public long antwoordID { get; set; }
        public string antwoord { get; set; }
        public long pollID { get; set; }
        public long aantalStemmen { get; set; }
    }
}
