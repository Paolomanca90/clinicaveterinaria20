namespace clinicaveterinaria20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visita")]
    public partial class Visita
    {
        [Key]
        public int idvisita { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? datavisita { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo oblicagatorio")]
        public string esame { get; set; }

        public string cura { get; set; }

        [Required(ErrorMessage = "Campo oblicagatorio")]
        public int? idanimale { get; set; }

        public virtual Animale Animale { get; set; }
    }
}