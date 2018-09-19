using System.Linq;
using System.Net;
using System.Web.Http;
using SportBets.API.Mapping;
using SportBets.API.Models;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.Interfaces;
using SportBets.BLL.InterfaceForService;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Finder;
using SportBets.DAL.Repositories;

namespace SportBets.API.Controllers
{
    public class HorseController : ApiController
    {
        private readonly SportBetsContext _context;
        private readonly IHorseFinder _horseFinder;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Horse> _repository;
        private readonly IHorseService _horseService;


        public HorseController(SportBetsContext context,
                               IHorseFinder horseFinder,
                               IUnitOfWork unitOfWork,
                               IRepository<Horse> repository,
                               IHorseService horseService)
        {
            _context = context;
            _horseFinder = horseFinder;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _horseService = horseService;
        }

        [HttpPost]
        [Route("Horse/CreateHorse")]
        public IHttpActionResult CreateHorse(HorseModel horse)
        {
            var mappedHorse = HorseMapping.Map(horse);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_horseService.CreateHorse(mappedHorse));
        }

        [HttpDelete]
        [Route("Horse/DeleteHorse/{id}")]
        public void DeleteHorse(int id)
        {
            var horseToDelete = _horseService.GetHorseById(id);
            if (horseToDelete == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _horseService.DeleteHorse(horseToDelete.FirstOrDefault());
        }

        [HttpGet]
        [Route("Horse/ById/{id}")]
        public IHttpActionResult ById(int id)
        {
            var horse = _horseService.GetHorseById(id).FirstOrDefault();
            if (horse == null)
            {
                return NotFound();
            }

            return Ok(horse);
        }

        [HttpGet]
        [Route("Horse/ByAge/{age}")]
        public IHttpActionResult ByAge(int age)
        {
            var horse = _horseService.GetHorsesByAge(age);
            if (horse == null)
            {
                return NotFound();
            }

            return Ok(horse);
        }

        [HttpGet]
        [Route("Horse/ByWeight/{weight:float}")]
        public IHttpActionResult ByWeight(float weight)
        {
            var horses = _horseService.GetHorsesByWeight(weight);
            if (horses == null)
            {
                return NotFound();
            }

            return Ok(horses);
        }

        [HttpGet]
        [Route("Horse/ByWins/{wins}")]
        public IHttpActionResult ByWins(int wins)
        {
            var horses = _horseService.GetHorsesByWins(wins);
            if (horses == null)
            {
                return NotFound();
            }

            return Ok(horses);
        }

        [HttpGet]
        [Route("Horse/ByLosses/{losses}")]
        public IHttpActionResult ByLosses(int losses)
        {
            var horses = _horseService.GetHorsesByLosses(losses);
            if (horses == null)
            {
                return NotFound();
            }

            return Ok(horses);
        }

        [HttpGet]
        [Route("Horse/ByName/{name}")]
        public IHttpActionResult ByName(string name)
        {
            var horses = _horseService.GetHorsesByName(name);
            if (horses == null)
            {
                return NotFound();
            }

            return Ok(horses);
        }
    }
}
