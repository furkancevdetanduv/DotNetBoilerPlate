using EFCoreLayer;
using EFCoreLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonaKalsınV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ProjectDbContext _dbContext;

        public WeatherForecastController(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet, Route("GetTestModel")]
        public async Task<TestModel> GetTestModel(int id)
        {
            return await _dbContext.testModels.FindAsync(id);
        }

        [HttpPost]
        public async Task<bool> AddNewTestModel(string name)
        {
            await _dbContext.testModels.AddAsync(new TestModel() { Name = name });
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
