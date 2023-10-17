namespace clinicaveterinaria20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Animale")]
    public partial class Animale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animale()
        {
            Visita = new HashSet<Visita>();
        }

        [Key]
        public int idanimale { get; set; }

        public DateTime? dataRegistrazione { get; set; }

        [StringLength(20)]
        public string nome { get; set; }

        [StringLength(20)]
        public string tipo { get; set; }

        [StringLength(20)]
        public string coloreMantello { get; set; }

        public DateTime? dataDinascita { get; set; }

        public bool? microchip { get; set; }

        [StringLength(50)]
        public string nmicrochip { get; set; }

        [StringLength(20)]
        public string nomeProprietario { get; set; }

        [StringLength(20)]
        public string cognomeProprietario { get; set; }

        public DateTime? datainizioricovero { get; set; }

        public DateTime? datafinericovero { get; set; }

        [StringLength(16)]
        public string codicefiscale { get; set; }

        public string foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visita> Visita { get; set; }
    }
}
