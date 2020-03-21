using COVID_19.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID_19.Map.Services
{
    public interface IDataService
    {
        Task<CovidData> GetData();
        void OrderDataWithColor(CovidData covidData);
    }
}