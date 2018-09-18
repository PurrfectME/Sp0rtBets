using System.Linq;
using System.Net;
using System.Web.Http;
using SportBets.API.Mapping;
using SportBets.API.Models;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.Interfaces;
using SportBets.BLL.Services;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Finder;
using SportBets.DAL.Repositories;

namespace SportBets.API.Controllers
{
    public class FootballTeamController : ApiController
    {
        private static readonly SportBetsContext _context = new SportBetsContext();
        private static readonly IUnitOfWork _unitOfWork = new UnitOfWork(_context);
        private static readonly IFootballTeamFinder _finder = new FootballTeamFinder(_context.FootballTeams);

        private static readonly IRepository<FootballTeam> _repository =
            new Repository<FootballTeam>(_context.FootballTeams);

        private static readonly FootballTeamService _teamService =
            new FootballTeamService(_unitOfWork, _finder, _repository);


        [HttpPost]
        [Route("FootballTeam/CreateTeam")]
        public IHttpActionResult CreateTeam(FootballTeamModel team)
        {
            var mappedTeam = FootballTeamMapping.Map(team);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_teamService.CreateTeam(mappedTeam));
        }

        [HttpDelete]
        [Route("FootballTeam/DeleteTeam/{id}")]
        public void DeleteTeam(int id)
        {
            var teamToDelete = _teamService.GetTeamsById(id).FirstOrDefault();

            if (teamToDelete == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _teamService.DeleteTeam(teamToDelete);
        }

        [HttpGet]
        [Route("FootballTeam/Byid/{id}")]
        public IHttpActionResult ById(int id)
        {
            var team = _teamService.GetTeamsById(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpGet]
        [Route("FootballTeam/ByName/{name}")]
        public IHttpActionResult ByName(string name)
        {
            var team = _teamService.GetTeamsByName(name);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpGet]
        [Route("FootballTeam/ByWins/{wins}")]
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
        [Route("FootballTeam/ByLosses/{losses}")]
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
