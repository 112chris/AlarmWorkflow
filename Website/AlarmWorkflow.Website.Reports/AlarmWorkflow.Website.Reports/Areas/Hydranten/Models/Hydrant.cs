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
        public int ID { get; set; }
        
        [Column(TypeName = "uint")]
        public long NrFF { get; set; }

        [Column(TypeName = "uint")]
        public long? NrWW { get; set; }

        [Required]
        [StringLength(50)]
        public string Barcode { get; set; }

        [Column(TypeName = "uint")]
        public long? Postcode { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Suburb { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(6)]
        public string Housenumber { get; set; }

        public int Location { get; set; }

        [StringLength(16777215)]
        public string Comment { get; set; }

        public decimal Lat { get; set; }

        [Required]
        public bool Type { get; set; }

        [Column(TypeName = "uint")]
        public long? Diam { get; set; }

        [Column(TypeName = "uint")]
        public long? Pressure { get; set; }

        [Column(TypeName = "uint")]
        public long? Amount { get; set; }
        
        [Required]
        [Column(TypeName = "date")]
        public DateTime LastCheck { get; set; }

        public int LastResult { get; set; }

        [Column(TypeName = "bit")]
        public bool Ready { get; set; }

        [Required]
        [StringLength(16777215)]
        public string CommentCheck { get; set; }

        public virtual Hydrant_Ergebnis hydrant_ergebnis { get; set; }

        public virtual Hydrant_Lage hydrant_lage { get; set; }
    }
}
