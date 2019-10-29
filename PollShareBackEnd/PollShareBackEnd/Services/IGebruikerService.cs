using PollShareBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollShareBackEnd.Services
{
    public interface IGebruikerService
    {
        Gebruiker Authenticate(string gebruikersnaam, string wachtwoord);
    }
}
