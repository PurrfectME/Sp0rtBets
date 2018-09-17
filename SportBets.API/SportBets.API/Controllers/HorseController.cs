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
    public class HorseController : ApiController
    {
        private static readonly SportBetsContext _context = new SportBetsContext();
        private static readonly IHorseFinder _horseFinder = new HorseFinder(_context.Horses);
        private static readonly IUnitOfWork _unitOfWork = new UnitOfWork(_context);
        private static readonly IRepository<Horse> _repository = new Repository<Horse>(_context.Horses);
        private static readonly HorseService _horseService = new HorseService(_unitOfWork, _horseFinder, _repository);
        

        [HttpPost]
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
        public IHttpActionResult ById(int id)
        {
            var horse = _horseService.GetHorseById(id).FirstOrDefault();
            if (horse == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Ok(horse);
        }

        [HttpGet]
        public IHttpActionResult ByAge(int age)
        {
            var horse = _horseService.GetHorsesByAge(age);
            if (horse == null)
            {
                return NotFound();
            }

            return Ok(horse);
        }
    }
}
