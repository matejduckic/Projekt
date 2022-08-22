namespace Projekt.Client.Services.VoziloService
{
    public interface IVoziloService
    {
        List<Vozilo> Vozila { get; set; }
        List<Tip> Tipovi { get; set; }
        Task GetTipove();
        Task GetVozila();
        Task<Vozilo> GetJednoVozilo(int Id);
        Task CreateVozilo(Vozilo vozilo);
        Task UpdateVozilo(Vozilo vozilo);
        Task DeleteVozilo(int Id);
    }
}
