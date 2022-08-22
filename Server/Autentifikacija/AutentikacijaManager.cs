using Projekt.Shared;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projekt.Server.Autentifikacija
{
    public class JwtAuthenticationManager
    {
        public const string JWT_SECURITY_KEY = "yPkCqn4kSWLtaJwXvN2jGzpQRyTZ3gdXkt7FeBJP";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;

        private DetaljiKorisnika _detaljiKorisnika;

        public JwtAuthenticationManager(DetaljiKorisnika detaljiKorisnika)
        {
            _detaljiKorisnika = detaljiKorisnika;
        }

        public SesijaKorisnika? GenerateJwtToken(string korisnickoIme, string lozinka)
        {
            if (string.IsNullOrWhiteSpace(korisnickoIme) || string.IsNullOrWhiteSpace(lozinka))
                return null;

            /* Validating the User Credentials */
            var korisnik = _detaljiKorisnika.GetUserAccountByUserName(korisnickoIme);
            if (korisnik == null || korisnik.Lozinka != lozinka)
                return null;

            /* Generating JWT Token */
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, korisnik.KorisnickoIme),
                    new Claim(ClaimTypes.Role, korisnik.Vrsta)
                });
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            /* Returning the User Session object */
            var sesijaKorisnika = new SesijaKorisnika
            {
                KorisnickoIme = korisnik.KorisnickoIme,
                Vrsta = korisnik.Vrsta,
                Token = token,
                VrijemeDoIsteka = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
            return sesijaKorisnika;
        }
    }
}
