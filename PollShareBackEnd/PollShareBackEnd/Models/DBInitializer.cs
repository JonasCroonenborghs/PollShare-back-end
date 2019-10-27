using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollShareBackEnd.Models
{
    public class DBInitializer
    {
        public static void Initialize(PollShareContext context)
        {
            context.Database.EnsureCreated();

            context.Gebruikers.AddRange(
                new Gebruiker {
                    email = "jonascroonenborghs@hotmail.com",
                    wachtwoord = "ww",
                    gebruikersnaam = "JonasC"
                });
            context.SaveChanges();

            context.PollGebruikers.AddRange(
                new PollGebruiker
                {
                    gebruikerID = 0,
                    pollID = 0
                });
            context.SaveChanges();
        }
    }
}
