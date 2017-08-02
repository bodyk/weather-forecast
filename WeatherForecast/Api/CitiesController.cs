using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public async Task<IQueryable<City>> GetCities()
        {
            return (IQueryable<City>) await _unitOfWorkService.GetAllCities();
        }

        // GET: api/Cities/Lviv
        [ResponseType(typeof(City))]
        [Route("api/Cities/{cityName}")]
        public async Task<IHttpActionResult> GetCity(string cityName)
        {
            City city = await _unitOfWorkService.FindCity(cityName);
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
        public async Task<IHttpActionResult> PutCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWorkService.UpdateCity(city);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cities
        [HttpPost]
        [Route("api/Cities/{city}")]
        public async Task<IHttpActionResult> PostCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWorkService.AddCity(city);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Cities/Lviv
        [ResponseType(typeof(City))]
        [HttpDelete]
        [Route("api/Cities/{cityName}")]
        public async Task<IHttpActionResult> DeleteCity(string cityName)
        {
            City city = await _unitOfWorkService.FindCity(cityName);
            if (city == null)
            {
                return NotFound();
            }

            await _unitOfWorkService.RemoveCity(city);

            return StatusCode(HttpStatusCode.NoContent);
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