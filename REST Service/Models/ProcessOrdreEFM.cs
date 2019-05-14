namespace REST_Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProcessOrdre")]
    public partial class ProcessOrdreEFM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProcessOrdreEFM()
        {
            Bemanding = new HashSet<BemandingEFM>();
            DeltilbageMeldt = new HashSet<DeltilbageMeldt>();
            PakkeKontrol = new HashSet<PakkeKontrolEFM>();
            //TappeKontrol = new HashSet<TappeKontrol>();
            //VaegtKontrol = new HashSet<VaegtKontrol>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Process_Ordre_Nr { get; set; }

        public int Faerdigvare_Nr { get; set; }

        [Column(TypeName = "date")]
        public DateTime Dato { get; set; }

        public int Kolonne { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BemandingEFM> Bemanding { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeltilbageMeldt> DeltilbageMeldt { get; set; }

        public virtual FaerdigvareEFM Faerdigvare { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PakkeKontrolEFM> PakkeKontrol { get; set; }

        //public virtual ProduktionsInformation ProduktionsInformation { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TappeKontrol> TappeKontrol { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<VaegtKontrol> VaegtKontrol { get; set; }
    }
}
