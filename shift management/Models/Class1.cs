using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shift_management.Models
{
    public class Turn
    {
        public int Id { get; set; } // clave primaria
        public int Number { get; set; }
        public string? Type { get; set; } // este puede ser de caja o afiliacion
        public DateTime DateHour { get; set; }
        public bool Attend { get; set; } = false;


    }
}
