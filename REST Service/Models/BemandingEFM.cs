namespace REST_Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bemanding")]
    public partial class BemandingEFM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Process_Order_Nr { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Tidspunk_Start { get; set; }

        public int Antal_Bemanding { get; set; }

        [Required]
        [StringLength(10)]
        public string Signatur { get; set; }

        public int? Pauser { get; set; }

        public virtual AnsatteEFM Ansatte { get; set; }

        public virtual ProcessOrdreEFM ProcessOrdre { get; set; }
    }
}
