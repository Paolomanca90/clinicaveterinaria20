namespace clinicaveterinaria20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Utente")]
    public partial class Utente
    {
        [Key]
        public int idutente { get; set; }

        [StringLength(50)]
        [Display(Name = "Inserisci Username")]
        public string username { get; set; }

        [StringLength(50)]
        [Display(Name = "Inserisci Password")]
        public string password { get; set; }

        [StringLength(20)]
        [Display(Name = "Inserisci Ruolo")]
        public string role { get; set; }
    }
}
