using System;
using System.Collections.Generic;
using System.Text;

namespace COVID_19.Shared.Models
{
    public class CovidData
    {
        public string DateUpdated { get; set; }
        public int TotalPositive { get; set; }
        public List<DataByCounty> DataByCounty { get; set; }
    }
}
