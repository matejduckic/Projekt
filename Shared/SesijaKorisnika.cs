using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Shared
{
    public class SesijaKorisnika
    {
        public string KorisnickoIme { get; set; }
        public string Token { get; set; }
        public string Vrsta { get; set; }
        public int  VrijemeDoIsteka { get; set; }
        public DateTime Date { get; set; }
    }
}
