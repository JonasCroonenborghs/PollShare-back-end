using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollShareBackEnd.Models
{
    public class Melding
    {
        public long meldingID { get; set; }
        public long huidigeGebruikerID { get; set; }
        public long vriendID { get; set; }
        public bool aanvaard { get; set; }
    }
}
