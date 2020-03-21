using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace COVID_19.Components.Components
{
    public class LegendBase:ComponentBase
    {
        [Parameter]
        public List<string> Colors { get; set; } = new List<string>();
        [Parameter]
        public decimal Min { get; set; }
        [Parameter]
        public decimal Max { get; set; }

    }
}
