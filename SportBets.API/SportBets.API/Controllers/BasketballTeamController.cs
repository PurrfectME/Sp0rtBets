using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class BasketballTeamController : ApiController
    {
        private static readonly SportBetsContext _context = new SportBetsContext();
        private static readonly IUnitOfWork _unitOfWork = new UnitOfWork(_context);
        private static readonly IBasketballTeamFinder _finder = new BasketballTeamFinder(_context.BasketballTeams);
        private static readonly IRepository<BasketballTeam> _repository =
            new Repository<BasketballTeam>(_context.BasketballTeams);
        private static readonly BasketballTeamService _teamService = new BasketballTeamService(_unitOfWork, _finder, _repository);


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
