using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVID_19.Api.Services;
using COVID_19.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COVID_19.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class COVID19Controller : ControllerBase
    {
        private DataLoaderService _dataLoaderService;
        public COVID19Controller(DataLoaderService dataLoaderService)
        {
            _dataLoaderService = dataLoaderService;
        }
        [HttpGet]
        public async Task<CovidData> GetDataByCounty() {
            var data = await _dataLoaderService.GetDataAsync();
            return data;
        }
    }
}