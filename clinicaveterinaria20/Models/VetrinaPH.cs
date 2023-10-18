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
        [Display(Name = "Inserisci il costo totale")]

        public decimal? costotot { get; set; }

        [StringLength(50)]
        [Display(Name = "Inserisci il numero della ricetta")]
        public string nricetta { get; set; }
        [Display(Name = "Inserisci la quantità")]

        public int? quantita { get; set; }
        [Display(Name = "Inserisci la data di vendita")]

        public DateTime? datavendita { get; set; }

        public int? idprodotto { get; set; }

        public int? idcliente { get; set; }
    }
}