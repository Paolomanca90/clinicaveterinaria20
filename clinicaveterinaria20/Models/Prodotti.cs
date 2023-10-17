namespace clinicaveterinaria20.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodotti")]
    public partial class Prodotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodotti()
        {
            Vendita = new HashSet<Vendita>();
        }

        [Key]
        public int idprodotto { get; set; }

        [StringLength(200)]
        public string nome { get; set; }

        public bool? tipologia { get; set; }

        [StringLength(200)]
        public string foto { get; set; }

        public int? quantita { get; set; }

        public decimal? costo { get; set; }

        public int? idcassetto { get; set; }

        public int? idutilizzo { get; set; }

        public int? idbrand { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Cassetto Cassetto { get; set; }

        public virtual Utilizzi Utilizzi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vendita> Vendita { get; set; }
    }
}
