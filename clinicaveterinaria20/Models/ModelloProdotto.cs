using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace clinicaveterinaria20.Models
{
    [NotMapped]
    public class ModelloProdotto
    {
        [Key]
        public int idprodotto { get; set; }

        [StringLength(200)]
        public string nome { get; set; }

        public bool? tipologia { get; set; }

        [StringLength(200)]
        public string foto { get; set; }

        public int? quantita { get; set; }

        public decimal? costo { get; set; }

        public int? casetto { get; set; }

        public string armadietto { get; set; }

        public int? brand { get; set; }
    }
}