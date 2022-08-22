namespace Projekt.Server.Autentifikacija
{
    public class DetaljiKorisnika
    {
        private List<Korisnik> _listaKorisnika;

        public DetaljiKorisnika()
        {
            _listaKorisnika = new List<Korisnik>
        {
            new Korisnik{ KorisnickoIme = "koordinator", Lozinka = "koordinator", Vrsta = "Administrator" },
            new Korisnik{ KorisnickoIme = "tehnolog", Lozinka = "tehnolog", Vrsta= "Korisnik" }
        };
        }

        public Korisnik? GetUserAccountByUserName(string korisnickoIme)
        {
            return _listaKorisnika.FirstOrDefault(x => x.KorisnickoIme == korisnickoIme);
        }
    }
}

