namespace clinicaveterinaria20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Armadietti")]
    public partial class Armadietti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Armadietti()
        {
            Cassetto = new HashSet<Cassetto>();
        }

        [Key]
        public int idarmadietto { get; set; }

        [NotMapped]
        [Display(Name = "inserire numero casetti del armadietto")]
        [Required(ErrorMessage = "campo obligatorio")]
        public int nCassettti { get; set; }

        [Display(Name = "Codice Armadietto")]
        [Required(ErrorMessage = "campo obligatorio")]
        public string codice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cassetto> Cassetto { get; set; }
    }
}