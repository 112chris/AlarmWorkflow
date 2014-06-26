// This file is part of AlarmWorkflow.
// 
// AlarmWorkflow is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// AlarmWorkflow is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with AlarmWorkflow.  If not, see <http://www.gnu.org/licenses/>.

namespace AlarmWorkflow.Website.Reports.Areas.Hydranten.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("alarmworkflow.hydrant_lage")]
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
