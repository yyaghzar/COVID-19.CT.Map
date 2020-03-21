using COVID_19.Map.Services;
using COVID_19.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Map.Pages
{
    public class COVIDBase:ComponentBase
    {
        [Inject]
        public IDataService DataService { get; set; }

       

        public CovidData COVIDData { get; set; }

        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public List<string> Colors { get; set; }
        protected async override Task OnInitializedAsync()
        {

            COVIDData = await DataService.GetData();
            DataService.OrderDataWithColor(COVIDData);
            Min = COVIDData.DataByCounty.Min(item => item.TotalCases);
            Max = COVIDData.DataByCounty.Max(item => item.TotalCases);
            Colors = COVIDData.DataByCounty.Select(item => item.Color).ToList();


        }
        
        
    }
}
