using System.ComponentModel;

namespace AlarmWorkflow.Website.Reports.Areas.Hydranten.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hydranten.hydranten")]
    public partial class Hydrant
    {
        [DisplayName("Interne Datenbanknummer")]
        public int ID { get; set; }

        [DisplayName("Interne Feuerwehr-Nr.")]
        [Column(TypeName = "uint")]
        public long NrFF { get; set; }

        [DisplayName("Interne Wasserwerke-Nr.")]
        [Column(TypeName = "uint")]
        public long? NrWW { get; set; }

        [DisplayName("Barcode")]
        [Required]
        [StringLength(50)]
        public string Barcode { get; set; }

        [DisplayName("Postleitzahl")]
        [Column(TypeName = "uint")]
        public long? Postcode { get; set; }

        [DisplayName("Stadt")]
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [DisplayName("Stadtteil")]
        [Required]
        [StringLength(50)]
        public string Suburb { get; set; }

        [DisplayName("Straße")]
        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [DisplayName("Hausnummer")]
        [StringLength(6)]
        public string Housenumber { get; set; }

        [DisplayName("Lage des Hydranten")]
        public int Location { get; set; }

        [DisplayName("Kommentar")]
        [StringLength(16777215)]
        public string Comment { get; set; }

        [DisplayName("Latitude")]
        public decimal Lat { get; set; }

        [DisplayName("Longitude")]
        public decimal Lng { get; set; }

        [DisplayName("Oberflurhydrant")]
        [Required]
        public bool Type { get; set; }

        [DisplayName("Durchmesser")]
        [Column(TypeName = "uint")]
        public long? Diam { get; set; }

        [DisplayName("Förderdruck")]
        [Column(TypeName = "uint")]
        public long? Pressure { get; set; }

        [DisplayName("Fördermenge")]
        [Column(TypeName = "uint")]
        public long? Amount { get; set; }

        [DisplayName("Letzte Prüfung")]
        [Required]
        [Column(TypeName = "date")]
        public DateTime LastCheck { get; set; }

        [DisplayName("Letztes Ergebnis")]
        public int LastResult { get; set; }

        [DisplayName("Einsatzklar")]
        [Column(TypeName = "bit")]
        public bool Ready { get; set; }

        [DisplayName("Kommentar zur Prüfung")]
        [Required]
        [StringLength(16777215)]
        public string CommentCheck { get; set; }

        public virtual Hydrant_Ergebnis hydrant_ergebnis { get; set; }

        public virtual Hydrant_Lage hydrant_lage { get; set; }
    }
}
