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

            //if (context.Gebruikers.Any() || 
            //    context.PollGebruikers.Any() ||
            //    context.Polls.Any() ||
            //    context.Stemmen.Any() || 
            //    context.Antwoorden.Any() ||
            //    context.Meldingen.Any() ||
            //    context.Vriendschappen.Any()) 
            //{
            //    return;
            //}

            //context.Gebruikers.AddRange(
            //    new Gebruiker {
            //        email = "jonascroonenborghs@hotmail.com",
            //        wachtwoord = "JonasC",
            //        gebruikersnaam = "JonasC",
            //        geactiveerd = true
            //    });
            //context.SaveChanges();

            //context.PollGebruikers.AddRange(
            //    new PollGebruiker
            //    {
            //        gebruikerID = 0,
            //        pollID = 0
            //    });
            //context.SaveChanges();

            //context.Polls.AddRange(
            //    new Poll
            //    {
            //        naam = "Cinema",
            //        makerID = 1
            //    });
            //context.SaveChanges();

            //context.Stemmen.AddRange(
            //    new Stem
            //    {
            //        antwoordID = 0,
            //        gebruikerID = 0
            //    });
            //context.SaveChanges();

            //context.Antwoorden.AddRange(
            //    new Antwoord
            //    {
            //        antwoord = "Test antwoord",
            //        pollID = 1
            //    });
            //context.SaveChanges();

            //context.Meldingen.AddRange(
            //    new Melding
            //    {
            //        huidigeGebruikerID = 1,
            //        vriendID = 2,
            //        type = "Vriendsapsverzoek"
            //    });
            //context.SaveChanges();
        }
    }
}
