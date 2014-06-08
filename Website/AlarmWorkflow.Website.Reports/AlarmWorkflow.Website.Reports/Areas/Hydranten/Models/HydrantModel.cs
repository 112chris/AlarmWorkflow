using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlarmWorkflow.Website.Reports.Areas.Hydranten.Models
{
    public class HydrantModel
    {
        public double Lat { get; set; }

        public double Lng { get; set; }

        public int ID { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public int PostCode { get; set; }

        public string City { get; set; }

        public string Comment { get; set; }

        public string Image { get; set; }
    }
}