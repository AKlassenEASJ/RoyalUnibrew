namespace REST_Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeltilbageMeldt")]
    public partial class DeltilbageMeldt
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Process_Order_Nr { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Tidspunkt { get; set; }

        public int Paller { get; set; }

        [StringLength(100)]
        public string Noter { get; set; }

        public int Tappetal { get; set; }

        public virtual ProcessOrdre ProcessOrdre { get; set; }
    }
}
