namespace REST_Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaegtKontrol")]
    public partial class VaegtKontrol
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Process_Ordre_Nr { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Kontrol_Nr { get; set; }

        [Column(TypeName = "date")]
        public DateTime Dato_Tid { get; set; }

        public virtual ProcessOrdre ProcessOrdre { get; set; }
    }
}
