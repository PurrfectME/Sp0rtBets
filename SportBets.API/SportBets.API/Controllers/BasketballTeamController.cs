using System.Linq;
using System.Net;
using System.Web.Http;
using SportBets.API.Mapping;
using SportBets.API.Models;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.InterfaceForService;
using SportBets.BLL.Interfaces;
using SportBets.DAL.EntitiesContext;

namespace SportBets.API.Controllers
{
    public class BasketballTeamController : ApiController
    {
        private readonly SportBetsContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketballTeamFinder _finder;
        private readonly IRepository<BasketballTeam> _repository;
        private readonly IBasketballTeamService _teamService;


        public BasketballTeamController(SportBetsContext context, 
                                        IUnitOfWork unitOfWork,
                                        IBasketballTeamFinder finder,
                                        IRepository<BasketballTeam> repository,
                                        IBasketballTeamService teamService)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _finder = finder;
            _repository = repository;
            _teamService = teamService;
        }


        [HttpPost]
        [Route("BasketballTeam/CreateTeam")]
        public IHttpActionResult CreateTeam(BasketballTeamModel team)
        {
            var mappedTeam = BasketballTeamMapping.Map(team);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_teamService.CreateTeam(mappedTeam));
        }

        [HttpDelete]
        [Route("BasketballTeam/DeleteTeam/{id}")]
        public void DeleteTeam(int id)
        {
            var teamToDelete = _teamService.GetTeamById(id).FirstOrDefault();
            if (teamToDelete == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _teamService.DeleteTeam(teamToDelete);
        }

        [HttpGet]
        [Route("BasketballTeam/ById/{id}")]
        public IHttpActionResult ById(int id)
        {
            var team = _teamService.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpGet]
        [Route("BasketballTeam/ByName/{name}")]
        public IHttpActionResult ByName(string name)
        {
            var team = _teamService.GetTeambyName(name);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpGet]
        [Route("BasketballTeam/ByWins/{wins}")]
        public IHttpActionResult ByWins(int wins)
        {
            var team = _teamService.GetTeamsByWins(wins);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpGet]
        [Route("BasketballTeam/ByLosses/{losses}")]
        public IHttpActionResult ByLosses(int losses)
        {
            var team = _teamService.GetTeamsByLosses(losses);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }
    }
}
