using COVID_19.Shared.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace COVID_19.Api.Services
{
    public class DataLoaderService
    {
        private HttpClient _httpClient;
        public DataLoaderService(HttpClient client)
        {
            _httpClient = client;

        }

        public async Task<CovidData> GetDataAsync() {

            var response = await  _httpClient.GetAsync("Coronavirus");
            var pageContent = await response.Content.ReadAsStringAsync();
            var pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(pageContent);       
            var siteData = GenerateTestingData(pageDocument);

            
            return siteData;
            
        }

        public IEnumerable<DataByCounty> GetDataByCounty(HtmlNodeCollection collection)
        {
            for(var i = 0; i < (collection.Count) - 1;i++)
            {
                var item = collection[i];
                var countyName = item.InnerText.Split("\n")[1].Trim();
                var number = item.InnerText.Split("\n")[2].Trim();
                yield return new DataByCounty
                {
                    County = countyName,
                    TotalCases = int.Parse(number)
                };
            }
        }
        public IEnumerable<DataByCounty> GetDataByCountys(List<string> items) {


            foreach (var item in items) {
                var countyName = item.Split(":")[0].Trim();
                var number = item.Split(":")[1].Trim();
                yield return new DataByCounty
                {
                    County = countyName,
                    TotalCases = int.Parse(number)
                };
            }
        }

        public CovidData GenerateTestingData(HtmlDocument document) {

            //var data = document.DocumentNode.SelectSingleNode("(//table/tbody/tr[1]/td/em)").InnerText;
            var dateUpdated = document.DocumentNode.SelectSingleNode("(//table/tbody/tr[1]/td/em)").InnerText;
            var totalPositive = document.DocumentNode.SelectSingleNode("(//table/tbody/tr[last()]/td[2]/strong)").InnerText;           
            var siteData = document.DocumentNode.SelectNodes("(//table/tbody/tr[position()>2])");
            var dataByCounty = GetDataByCounty(siteData);

            return new CovidData()
            {
                DateUpdated = dateUpdated,
                TotalPositive = int.Parse(totalPositive),
                DataByCounty = dataByCounty.ToList()

            };
        }
    }
}
