using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace clinicaveterinaria20.Models
{
    public class ModelloProdotto
    {
        [Key]
        public int idprodotto { get; set; }

        [StringLength(200)]
        [Display(Name = "Inserisci il nome del Prodotto")]
        public string nome { get; set; }

        [Display(Name = "Inserisci la tipologia del Prodotto")]
        public bool? tipologia { get; set; }

        [StringLength(200)]
        [Display(Name = "Inserisci un'immagine del Prodotto")]
        public string foto { get; set; }

        [Display(Name = "Inserisci la quantità del Prodotto")]
        public int? quantita { get; set; }

        [Display(Name = "Inserisci il prezzo del Prodotto")]
        public decimal? costo { get; set; }

        [Display(Name = "Inserisci il cassetto corrispondente")]
        public int? casetto { get; set; }

        [Display(Name = "Inserisci l'armadietto corrispondente")]
        public string armadietto { get; set; }

        [Display(Name = "Inserisci il nome del Brand")]
        public int? brand { get; set; }

        public bool invendita { get; set; }
    }
}