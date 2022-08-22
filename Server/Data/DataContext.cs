namespace Projekt.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tip>().HasData(
                new Tip
                {
                    Id = 1,
                    Naziv = "autobus",
                },
                new Tip
                {
                    Id = 2,
                    Naziv = "tramvaj",
                }
                );

            modelBuilder.Entity<Vozilo>().HasData(
                new Vozilo
                {
                    Id = 1,
                    VoznaLinija = "1",
                    Naziv = "autobus1",
                    Km = "1234500",
                    TipId = 1,
                },
                new Vozilo
                {
                    Id = 2,
                    VoznaLinija = "2",
                    Naziv = "tramvaj1",
                    Km = "3459800",
                    TipId = 2,
                }
                ) ;
        }

        public DbSet<Vozilo> Vozila { get; set; }
        public DbSet<Tip> Tipovi { get; set; }


    }
}
