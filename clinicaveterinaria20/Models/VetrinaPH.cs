using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinicaveterinaria20.Models
{
    public class VetrinaPH
    {
        [Key]
        public int idvendita { get; set; }

        public decimal? costotot { get; set; }

        [StringLength(50)]
        public string nricetta { get; set; }

        public int? quantita { get; set; }

        public DateTime? datavendita { get; set; }

        public int? idprodotto { get; set; }

        public int? idcliente { get; set; }
    }
}