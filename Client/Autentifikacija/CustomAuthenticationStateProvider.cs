using Blazored.SessionStorage;
using Projekt.Client.Extensions;
using Projekt.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Projekt.Client.Autentifikacija
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var sesijaKorisnika = await _sessionStorage.ReadEncryptedItemAsync<SesijaKorisnika>("SesijaKorisnika");
                if (sesijaKorisnika == null)
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sesijaKorisnika.KorisnickoIme),
                    new Claim(ClaimTypes.Role, sesijaKorisnika.Vrsta)
                }, "JwtAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAuthenticationState(SesijaKorisnika? sesijaKorisnika)
        {
            ClaimsPrincipal claimsPrincipal;

            if (sesijaKorisnika != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sesijaKorisnika.KorisnickoIme),
                    new Claim(ClaimTypes.Role, sesijaKorisnika.Vrsta)
                }));
                sesijaKorisnika.Date = DateTime.Now.AddSeconds(sesijaKorisnika.VrijemeDoIsteka);
                await _sessionStorage.SaveItemEncryptedAsync("SesijaKorisnika", sesijaKorisnika);
            }
            else
            {
                claimsPrincipal = _anonymous;
                await _sessionStorage.RemoveItemAsync("SesijaKorisnika");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task<string> GetToken()
        {
            var result = string.Empty;

            try
            {
                var sesijaKorisnika = await _sessionStorage.ReadEncryptedItemAsync<SesijaKorisnika>("SesijaKorisnika");
                if (sesijaKorisnika != null && DateTime.Now < sesijaKorisnika.Date)
                    result = sesijaKorisnika.Token;
            }
            catch { }

            return result;
        }
    }
}
