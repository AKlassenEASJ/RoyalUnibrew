namespace REST_Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ansatte")]
    public partial class Ansatte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ansatte()
        {
            Bemanding = new HashSet<Bemanding>();
            PakkeKontrol = new HashSet<PakkeKontrolEFM>();
            ProduktionsInformation = new HashSet<ProduktionsInformation>();
            TappeKontrol = new HashSet<TappeKontrol>();
        }

        [Key]
        [StringLength(10)]
        public string Initialer { get; set; }

        [Required]
        [StringLength(50)]
        public string Navn { get; set; }

        public int ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bemanding> Bemanding { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PakkeKontrolEFM> PakkeKontrol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProduktionsInformation> ProduktionsInformation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TappeKontrol> TappeKontrol { get; set; }
    }
}
