using COVID_19.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COVID_19.Components.Components
{
    public class MapBase:ComponentBase
    {
        [Parameter]
        public List<DataByCounty> DataByCounty { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeVoidAsync(
                "GetItWorking", DataByCounty);
        }

    }
}
