using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;
using System.Threading.Tasks;

namespace webapi.Controllers
{   

    //FeedbackController hereda la clase ControllerBase, utilizada para el manejo
    //de endpoints.
    //FeedbackController Se encarga de manejar operaciones CRUD para la gestion de feedback.
    //Route especifica la ruta para este controlador. En este caso local:
    //ApiController identifica a la clase como un controlador en el framework.
    //EnableCors habilita el uso de CORS Request para el API, haciendo uso de una
    //politica default creada en Program.cs.
    //http://localhost:5054/api/feedback/
    [Route("api/feedback")]
    [ApiController]
    [EnableCors("DefaultPolicy")]
    public class FeedbackController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;

        //Se hace uso del singleton mongoDBService para conectar
        //con la base de datos en MongoDB y realizar las operaciones
        //CRUD permitidas por el API.
        public FeedbackController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        //CRUD ENDPOINTS:

        [HttpPost]
        public async Task<ActionResult> CreateFeedback(Feedback newFeedback)
        {
            await _mongoDBService.CreateFeedbackAsync(newFeedback);
            return Ok(newFeedback);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ReadFeedback(string id)
        {
            List<Feedback> feedback = await _mongoDBService.GetFeedbackAsync(id);
            return Ok(feedback);
        }

    }
}