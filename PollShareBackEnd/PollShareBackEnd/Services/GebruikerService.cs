using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PollShareBackEnd.Helpers;
using PollShareBackEnd.Models;

namespace PollShareBackEnd.Services
{
    public class GebruikerService : IGebruikerService
    {
        private readonly AppSettings _appSettings;
        private readonly PollShareContext _pollShareContext;

        public GebruikerService(IOptions<AppSettings> appSettings, PollShareContext pollShareContext)
        {
            _appSettings = appSettings.Value;
            _pollShareContext = pollShareContext;
        }

        public Gebruiker Authenticate(string gebruikersnaam, string wachtwoord)
        {
            var gebruiker = _pollShareContext.Gebruikers.SingleOrDefault(x => x.gebruikersnaam == gebruikersnaam && x.wachtwoord == wachtwoord);

            if (gebruiker == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("gebruikerID", gebruiker.gebruikerID.ToString()),
                    new Claim("email", gebruiker.email),
                    new Claim("gebruikersnaam", gebruiker.gebruikersnaam)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            gebruiker.token = tokenHandler.WriteToken(token);

            gebruiker.wachtwoord = null;

            return gebruiker;
        }
    }
}
