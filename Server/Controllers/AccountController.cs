using Projekt.Server.Autentifikacija;
using Projekt.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projekt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private DetaljiKorisnika _detaljiKorisnika;

        public AccountController(DetaljiKorisnika detaljiKorisnika)
        {
            _detaljiKorisnika= detaljiKorisnika;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<SesijaKorisnika> Login([FromBody] LoginRequest loginRequest)
        {
            var jwtAuthenticationManager = new JwtAuthenticationManager(_detaljiKorisnika);
            var sesijaKorisnika = jwtAuthenticationManager.GenerateJwtToken(loginRequest.KorisnickoIme, loginRequest.Lozinka);
            if (sesijaKorisnika is null)
                return sesijaKorisnika;
            else
                return sesijaKorisnika;
        }
    }
}
