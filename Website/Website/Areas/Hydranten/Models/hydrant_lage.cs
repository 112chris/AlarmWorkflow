namespace AlarmWorkflow.Website.Reports.Areas.Hydranten.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hydranten.hydrant_lage")]
    public partial class Hydrant_Lage
    {
        public Hydrant_Lage()
        {
            hydrantens = new HashSet<Hydrant>();
        }

        public int ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string Description { get; set; }

        public virtual ICollection<Hydrant> hydrantens { get; set; }
    }
}
