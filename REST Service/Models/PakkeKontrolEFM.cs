namespace REST_Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PakkeKontrol")]
    public partial class PakkeKontrolEFM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Process_Ordre_Nr { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Tidspunkt { get; set; }

        [StringLength(20)]
        public string Paa_Baner_Paller { get; set; }

        public int Folie_Raavare_Nr { get; set; }

        public int Karton_Raavare_Nr { get; set; }

        [Column(TypeName = "date")]
        public DateTime Holdbarheds_Dato { get; set; }

        [Column(TypeName = "date")]
        public DateTime Produktions_Dato { get; set; }

        [Required]
        [StringLength(15)]
        public string Printer1_Produktion_Dato { get; set; }

        [Required]
        [StringLength(15)]
        public string Printer1_Holdbarheds_Dato { get; set; }

        [StringLength(15)]
        public string Printer2_Produktion_Dato { get; set; }
         
        [StringLength(15)]
        public string Printer2_Holdbarheds_Dato { get; set; }

        [StringLength(10)]
        public string FyldeHojde_Kontrol { get; set; }

        [StringLength(10)]
        public string Skridlim_Karton { get; set; }

        [Required]
        [StringLength(10)]
        public string Kontrol_StabelMonster { get; set; }

        [Required]
        [StringLength(8)]
        public string Kontrol_Averylabel { get; set; }

        public double? Pu_Tunnelpasteur_V { get; set; }

        public double? Pu_Tunnelpasteur_M { get; set; }

        public double? Pu_Tunnelpasteur_H { get; set; }

        [Required]
        [StringLength(10)]
        public string Helhedsindtryk { get; set; }

        public int? Kontrol_Palle_Nr { get; set; }

        [StringLength(10)]
        public string Fremmede_Daaser_Karton { get; set; }

        [Required]
        [StringLength(10)]
        public string Signatur { get; set; }

        public virtual AnsatteEFM Ansatte { get; set; }

        public virtual ProcessOrdreEFM ProcessOrdre { get; set; }
    }
}
