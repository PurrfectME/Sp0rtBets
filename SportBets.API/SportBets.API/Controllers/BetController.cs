using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IHttpActionResult CreateBet([FromBody]Bet bet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _betService.CreateBet(bet);

            return Ok(bet);
        }
        
        [HttpDelete]
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