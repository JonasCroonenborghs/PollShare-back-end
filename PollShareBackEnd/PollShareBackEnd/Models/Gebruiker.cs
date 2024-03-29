﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PollShareBackEnd.Models
{
    public class Gebruiker
    {
        public long gebruikerID { get; set; }
        public string email { get; set; }
        public string wachtwoord { get; set; }
        public string gebruikersnaam { get; set; }
        [NotMapped]
        public string token { get; set; }
        public bool geactiveerd { get; set; }
    }
}
