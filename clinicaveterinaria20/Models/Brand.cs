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

        [Required]
        public string nome { get; set; }

        [Required]
        [StringLength(11)]
        public string piva { get; set; }

        [Required]
        [StringLength(56)]
        public string sedelegale { get; set; }

        [Required]
        [StringLength(15)]
        public string recapito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prodotti> Prodotti { get; set; }
    }
}