using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;
using System.Threading.Tasks;

namespace webapi.Controllers
{   
    [Route("webapi/series")]
    [ApiController]
    [EnableCors("DefaultPolicy")]
    public class SeriesController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;

        public SeriesController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        //CRUD ENDPOINTS:

        [HttpPost]
        public async Task<ActionResult> CreateSeries(Series newSeries)
        {
            await _mongoDBService.CreateSeriesAsync(newSeries);
            return Ok(newSeries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ReadSeries(string id)
        {
            List<Series> series = await _mongoDBService.GetSeriesAsync(id);
            return Ok(series);
        }

        [HttpGet]
        public async Task<ActionResult> ReadAllSeries()
        {
            List<Series> allSeries = await _mongoDBService.GetAllSeriesAsync();
            return Ok(allSeries);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSeriesName(string id, [FromBody] string seriesName)
        {
            await _mongoDBService.UpdateSeriesAsync(id,seriesName);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeries(string id)
        {
            await _mongoDBService.DeleteSeriesAsync(id);
            return NoContent();
        }

    }
}