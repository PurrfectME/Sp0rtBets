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
    public class BetController : ApiController
    {
        private static readonly SportBetsContext _context = new SportBetsContext();
        private static readonly IBetFinder _finder = new BetFinder(_context.Bets);
        private static readonly IUnitOfWork _unitOfWork = new UnitOfWork(_context);
        private static readonly IRepository<Bet> _repository = new Repository<Bet>(_context.Bets);
        private static readonly BetService _betService = new BetService(_unitOfWork, _finder, _repository);

        
        [HttpPost]
        [Route("Bet/CreateBet/")]
        public IHttpActionResult CreateBet(BetModel bet)
        {
            var mappedBet = BetMapping.Map(bet);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok(_betService.CreateBet(mappedBet));
        }
        
        [HttpDelete]
        [Route("Bet/DeleteBet/{id}")]
        public void DeleteBet(int id)
        {
            var betToDelete = _betService.GetBetById(id);
            if (betToDelete == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _betService.DeleteBet(betToDelete.FirstOrDefault());
        }

        [HttpGet]
        [Route("Bet/ById/{id}")]
        public IHttpActionResult ById(int id)
        {
            var bet = _betService.GetBetById(id).FirstOrDefault();
            if (bet == null)
            {
                return NotFound();
            }

            return Ok(bet);
        }

        [HttpGet]
        [Route("Bet/ByType/{type}")]
        public IHttpActionResult ByType(ItemType type)
        {
            var bet = _betService.GetBetsByType(type);
            if (bet == null)
            {
                return NotFound();
            }

            return Ok(bet);
        }

        [HttpGet]
        [Route("Bet/AllBets/")]
        public IHttpActionResult AllBets()
        {
            var bets = _betService.GetAllBets();
            if (bets == null)
            {
                return NotFound();
            }

            return Ok(bets);
        }

        [HttpGet]
        [Route("Bet/ByDate/{date}")]
        public IHttpActionResult ByDate(DateTime date)
        {
            var bets = _betService.GetBetsByDate(date);
            if (bets == null)
            {
                return NotFound();
            }

            return Ok(bets);
        }
        
    }
}