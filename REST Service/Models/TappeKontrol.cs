namespace REST_Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TappeKontrol")]
    public partial class TappeKontrol
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Process_Ordre_Nr { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Tidspunkt { get; set; }

        public int Daase_Nr { get; set; }

        public int Laag_Nr { get; set; }

        [StringLength(10)]
        public string Helhed { get; set; }

        [StringLength(10)]
        public string Kamera_Tjek { get; set; }

        [StringLength(10)]
        public string CCP { get; set; }

        public double Vaeske_Temp { get; set; }

        public double Kontrol_Temp { get; set; }

        [StringLength(35)]
        public string Tunnel_PH_Tjek { get; set; }

        public double? Vaegt_Kontrol { get; set; }

        public int? Smag_Test_Nr { get; set; }

        [StringLength(10)]
        public string Smag_Test { get; set; }

        [StringLength(30)]
        public string Kvitter_Proeve { get; set; }

        [StringLength(10)]
        public string Sukker_Tjek { get; set; }

        public double? CO2_Kontrol { get; set; }

        [Required]
        [StringLength(10)]
        public string Signatur { get; set; }

        public virtual Ansatte Ansatte { get; set; }

        public virtual ProcessOrdre ProcessOrdre { get; set; }
    }
}
