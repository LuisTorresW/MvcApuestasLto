using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasLto.Models
{
    [Table("APUESTAS")]
    public class Apuestas
    {
        [Key]
        [Column("IDAPUESTA")]
        public int IdApuesta { get; set; }

        [Column("USUARIO")]
        public string Usuario { get; set; }
        
        [Column("IDEQUIPOLOCAL")]

        public int IdEquipolocal { get; set; }

        [Column("IDEQUIPOVISITANTE")]

        public int IdEquipovisitante { get; set; }

        [Column("GOLESEQUIPOLOCAL")]

        public int Golesequipolocal { get; set; }

        [Column("GOLESEQUIPOVISITANTE")]

        public int GolesEquipoVisitante { get; set; }
    }
}
