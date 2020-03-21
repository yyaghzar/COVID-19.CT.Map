using COVID_19.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Map.Components
{
    public class COVIDTableBase:ComponentBase
    {
        [Parameter]
        public List<DataByCounty> DataByCounty { get; set; }
    }
}
