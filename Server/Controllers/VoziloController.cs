using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projekt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoziloController : ControllerBase
    {
        private readonly DataContext _context;

        public VoziloController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vozilo>>> GetVozila()
        {
            var vozila = await _context.Vozila.Include(sh => sh.Tip).ToListAsync();
            return Ok(vozila);
        }
        [HttpGet("tipovi")]
        public async Task<ActionResult<List<Tip>>> GetTipove()
        {
            var comics = await _context.Tipovi.ToListAsync();
            return Ok(comics);
        }


        [HttpGet("{VoznaLinijaId}")]
        public async Task<ActionResult<Vozilo>> GetJednoVozilo(int Id)
        {
            var vozilo = await _context.Vozila
                .Include(h => h.Tip)
                .FirstOrDefaultAsync(h => h.Id == Id);
            if (vozilo == null)
            {
                return NotFound("Nema takvog vozila");
            }
            return Ok(vozilo);
        }

        [HttpPost]
        public async Task<ActionResult<List<Vozilo>>> CreateVozilo(Vozilo vozilo)
        {
            vozilo.Tip = null;
            _context.Vozila.Add(vozilo);
            await _context.SaveChangesAsync();

            return Ok(await GetDbVozila());
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<List<Vozilo>>> UpdateVozilo(Vozilo vozilo, int Id)
        {
            var dbVozilo = await _context.Vozila
                .Include(sh => sh.Tip)
                .FirstOrDefaultAsync(sh => sh.Id == Id);
            if (dbVozilo == null)
                return NotFound("Nema takvog vozila");

            dbVozilo.VoznaLinija = vozilo.VoznaLinija;
            dbVozilo.Naziv = vozilo.Naziv;
            dbVozilo.Km = vozilo.Km;
            dbVozilo.TipId = vozilo.TipId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbVozila());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Vozilo>>> DeleteVozilo(int Id)
        {
            var dbVozilo = await _context.Vozila
                .Include(sh => sh.Tip)
                .FirstOrDefaultAsync(sh => sh.Id == Id);
            if (dbVozilo == null)
                return NotFound("Nema takvog vozila");

            _context.Vozila.Remove(dbVozilo);
            await _context.SaveChangesAsync();

            return Ok(await GetDbVozila());
        }

        private async Task<List<Vozilo>> GetDbVozila()
        {
            return await _context.Vozila.ToListAsync();
        }

    }
} 

        