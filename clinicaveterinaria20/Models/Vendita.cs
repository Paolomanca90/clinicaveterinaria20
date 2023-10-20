namespace clinicaveterinaria20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendita")]
    public partial class Vendita
    {
        [Key]
        public int idvendita { get; set; }
        [Display(Name = "Costo totale")]
        public decimal? costotot { get; set; }

        [StringLength(50)]
        [Display(Name = "Numero della ricetta")]
        public string nricetta { get; set; }
        [Display(Name = "Quantità")]

        public int? quantita { get; set; }
        [Display(Name = "Data di vendita")]

        public DateTime? datavendita { get; set; }

        public int? idprodotto { get; set; }

        public int? idcliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Prodotti Prodotti { get; set; }
    }
}
