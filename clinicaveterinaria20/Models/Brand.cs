namespace clinicaveterinaria20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public partial class Brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand()
        {
            Prodotti = new HashSet<Prodotti>();
        }

        [Key]
        public int idbrand { get; set; }

        [Required(ErrorMessage = "campo richiesto")]
        [Display(Name = "Nome Brand")]
        public string nome { get; set; }

        [StringLength(11)]
        [Display(Name = "Partita Iva")]
        public string piva { get; set; }

        [StringLength(56)]
        [Display(Name = "Sede Legale")]
        public string sedelegale { get; set; }

        [StringLength(15)]
        [Display(Name = "Recapito Telefonico")]
        public string recapito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prodotti> Prodotti { get; set; }
    }
}