namespace REST_Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProduktionsInformation")]
    public partial class ProduktionsInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Process_Order_Nr { get; set; }

        public int Paller_Lagt_Paa_Lager { get; set; }

        [Required]
        [StringLength(10)]
        public string Signatur { get; set; }

        public int SPIDSER { get; set; }

        public int Daase_pr_Karton { get; set; }

        [Column(TypeName = "date")]
        public DateTime Batch_Dato { get; set; }

        public int Karton_Pr_Palle { get; set; }

        public int Karton_Overskud { get; set; }

        public int Start_TU1 { get; set; }

        public int Slut_TU1 { get; set; }

        public int Start_TU2 { get; set; }

        public int Slut_TU2 { get; set; }

        public virtual Ansatte Ansatte { get; set; }

        public virtual ProcessOrdre ProcessOrdre { get; set; }
    }
}
