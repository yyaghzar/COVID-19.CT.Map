using System;
using System.Collections.Generic;
using System.Text;

namespace COVID_19.Shared.Models
{
    public class DataByCounty
    {
        public string County { get; set; }
        public decimal TotalCases { get; set; }

        public string Color { get; set; }
    }
}
