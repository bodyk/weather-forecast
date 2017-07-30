using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Api
{
    public class CitiesController : ApiController
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public CitiesController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: api/Cities
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public IQueryable<City> GetCities()
        {
            return (IQueryable<City>)_unitOfWorkService.GetAllCities();
        }

        // GET: api/Cities/Lviv
        [ResponseType(typeof(City))]
        [Route("api/Cities/{cityName}")]
        public IHttpActionResult GetCity(string cityName)
        {
            City city = _unitOfWorkService.FindCity(cityName);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/Lviv
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/Cities/{city}")]
        public IHttpActionResult PutCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWorkService.UpdateCity(city);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cities
        [ResponseType(typeof(City))]
        [HttpPost]
        [Route("api/Cities/{city}")]
        public IHttpActionResult PostCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWorkService.AddCity(city);

            return CreatedAtRoute("DefaultApi", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/Lviv
        [ResponseType(typeof(City))]
        [HttpDelete]
        [Route("api/Cities/{cityName}")]
        public IHttpActionResult DeleteCity(string cityName)
        {
            City city = _unitOfWorkService.FindCity(cityName);
            if (city == null)
            {
                return NotFound();
            }

            _unitOfWorkService.RemoveCity(city);

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWorkService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}