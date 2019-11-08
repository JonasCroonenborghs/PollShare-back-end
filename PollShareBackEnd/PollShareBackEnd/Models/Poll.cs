using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollShareBackEnd.Models
{
    public class Poll
    {
        public long pollID { get; set; }
        public string naam { get; set; }
        public List<Antwoord> antwoorden { get; set; }
        public List<Gebruiker> deelnemers { get; set; }
    }
}
