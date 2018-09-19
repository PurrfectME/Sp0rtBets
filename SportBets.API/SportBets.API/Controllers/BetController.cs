using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using SportBets.API.Mapping;
using SportBets.API.Models;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.InterfaceForService;
using SportBets.BLL.Interfaces;
using SportBets.BLL.Services;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Finder;
using SportBets.DAL.Repositories;

namespace SportBets.API.Controllers
{
    public class BetController : ApiController
    {
        private readonly SportBetsContext _context;
        private readonly IBetFinder _finder;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Bet> _repository;
        private readonly IBetService _betService;

        public BetController(SportBetsContext context,
                             IBetFinder finder,
                             IUnitOfWork unitOfWork,
                             IRepository<Bet> repository,
                             IBetService betService)
        {
            _context = context;
            _finder = finder;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _betService = betService;

        }


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