using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;
using System.Threading.Tasks;

namespace webapi.Controllers
{   

    //SeriesController hereda la clase ControllerBase, utilizada para el manejo
    //de endpoints.
    //SeriesController Se encarga de manejar operaciones CRUD para la gestion de series.
    //Route especifica la ruta para este controlador. En este caso local:
    //ApiController identifica a la clase como un controlador en el framework.
    //EnableCors habilita el uso de CORS Request para el API, haciendo uso de una
    //politica default creada en Program.cs.
    //http://localhost:5054/milista/series/
    [Route("milista/series")]
    [ApiController]
    [EnableCors("DefaultPolicy")]
    public class SeriesController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;

        //Se hace uso del singleton mongoDBService para conectar
        //con la base de datos en MongoDB y realizar las operaciones
        //CRUD permitidas por el API.
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