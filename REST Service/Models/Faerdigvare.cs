namespace REST_Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faerdigvare")]
    public partial class Faerdigvare
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faerdigvare()
        {
            ProcessOrdre = new HashSet<ProcessOrdre>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Faerdigvare_Nr { get; set; }

        [Required]
        [StringLength(50)]
        public string Navn { get; set; }

        public double Minimum { get; set; }

        public double Gennemsnit { get; set; }

        public double Maximum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProcessOrdre> ProcessOrdre { get; set; }
    }
}
