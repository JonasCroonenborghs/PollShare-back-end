using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollShareBackEnd.Models
{
    public class Vriendschap
    {
        public long vriendschapID { get; set; }
        public long gebruikerID { get; set; }
        public long vriendID { get; set; }
    }
}
