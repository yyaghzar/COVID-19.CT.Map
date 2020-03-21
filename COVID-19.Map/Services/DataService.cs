using COVID_19.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace COVID_19.Map.Services
{
    public class DataService : IDataService
    {
        private HttpClient _httpClient;
        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CovidData> GetData()
        {
            var data = await _httpClient.GetJsonAsync<CovidData>("/api/covid19");
            return data;
        }

        public void OrderDataWithColor(CovidData covidData) {

            var dataByCounty = covidData.DataByCounty.OrderBy(item => item.TotalCases).ToList();
            decimal min = dataByCounty.Min(item => item.TotalCases);
            decimal max = dataByCounty.Max(item => item.TotalCases);

            Color secondColour = Color.RoyalBlue;
            Color firstColour = Color.LightSkyBlue; 

            int rOffset = Math.Max(firstColour.R, secondColour.R);
            int gOffset = Math.Max(firstColour.G, secondColour.G);
            int bOffset = Math.Max(firstColour.B, secondColour.B);

            int deltaR = Math.Abs(firstColour.R - secondColour.R);
            int deltaG = Math.Abs(firstColour.G - secondColour.G);
            int deltaB = Math.Abs(firstColour.B - secondColour.B);


            foreach (var item in dataByCounty) {
                var color = ColorTranslator.ToHtml(GetColor(item.TotalCases));
                item.Color = color;
            }
            covidData.DataByCounty = dataByCounty;

            Color GetColor(decimal totalCases)
            {
                decimal val = (totalCases - max) / (min - max);
                int r = rOffset - Convert.ToByte(deltaR * (1 - val));
                int g = gOffset - Convert.ToByte(deltaG * (1 - val));
                int b = bOffset - Convert.ToByte(deltaB * (1 - val));

               
                return Color.FromArgb(255, r, g, b);
            }
        }
    }
}
