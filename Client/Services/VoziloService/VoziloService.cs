using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Projekt.Client.Services.VoziloService
{
    public class VoziloService : IVoziloService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public VoziloService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Vozilo> Vozila { get; set; } = new List<Vozilo>();
        public List<Tip> Tipovi { get ; set ; } = new List<Tip>();

        public async Task CreateVozilo(Vozilo vozilo)
        {
            var result = await _http.PostAsJsonAsync("api/vozilo", vozilo);
            await SetVozila(result);
        }
        private async Task SetVozila(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Vozilo>>();
            Vozila = response;
            _navigationManager.NavigateTo("vozila");
        }

        public async Task DeleteVozilo(int Id)
        {
            var result = await _http.DeleteAsync($"api/vozilo/{Id}");
            await SetVozila(result);
        }

        public async Task<Vozilo> GetJednoVozilo(int Id)
        {
            var result = await _http.GetFromJsonAsync<Vozilo>($"api/vozilo/{Id}");
            if (result != null)
                return result;
            throw new Exception("Nema takvog vozila");
        }

        public async Task GetVozila()
        {
            var result = await _http.GetFromJsonAsync<List<Vozilo>>("api/vozilo");
            if (result != null)
                Vozila = result;
        }

        public async Task UpdateVozilo(Vozilo vozilo)
        {
            var result = await _http.PutAsJsonAsync($"api/vozilo/{vozilo.Id}", vozilo);
            await SetVozila(result);
        }

        public async Task GetTipove()
        {
            var result = await _http.GetFromJsonAsync<List<Tip>>("api/vozilo/tipovi");
            if (result != null)
                Tipovi = result;
        }

       


    }
}
