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

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dataRegistrazione { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(20)]
        [Display(Name = "Inserisci il nome dell'animale")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(20)]
        [Display(Name = "Inserisci la specie dell'animale")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(20)]
        [Display(Name = "Inserisci il colore del mantello")]
        public string coloreMantello { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Inserisci data di nascita dell'animale")]
        public DateTime? dataDinascita { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Specifica se ha un microchip")]
        public bool? microchip { get; set; }

        [StringLength(50)]
        [Display(Name = "Inserisci il numero del microchip")]
        public string nmicrochip { get; set; }

        [StringLength(20)]
        [Display(Name = "Inserisci il nome del proprietario")]
        public string nomeProprietario { get; set; }

        [StringLength(20)]
        [Display(Name = "Inserisci il cognome del proprietario")]
        public string cognomeProprietario { get; set; }
        [Display(Name = "Inserisci data di inizio ricovero")]
        public DateTime? datainizioricovero { get; set; }
        [Display(Name = "Inserisci data di fine ricovero")]

        public DateTime? datafinericovero { get; set; }

        [StringLength(16)]
        [Display(Name = "Inserisci il Codice Fiscale del proprietario")]
        public string codicefiscale { get; set; }
        [Display(Name = "Inserisci la foto dell'animale")]

        public string foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visita> Visita { get; set; }

    }
}
