using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlarmWorkflow.Website.Reports.Areas.Hydranten.Models
{
    public class SearchModel
    {
        [DisplayName("Zu suchender Begriff")]
        [Required]
        public string QueryString { get; set; }
    }
}