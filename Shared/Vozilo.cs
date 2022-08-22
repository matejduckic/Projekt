using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Shared
{

    public class Vozilo
    {

        public int Id { get; set; }
        public string VoznaLinija { get; set; } = string.Empty;
        public string Naziv { get; set; } = string.Empty;
        public string Km { get; set; } = string.Empty;
        public Tip? Tip { get; set; }
        public int TipId {get; set;}
    }
}
