using System;
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
    public class UserController : ApiController
    {
        private static readonly SportBetsContext _context = new SportBetsContext();
        private static readonly IUnitOfWork _unitOfWork = new UnitOfWork(_context);
        private static readonly IUserFinder _userFinder = new UserFinder(_context.Users);
        private static readonly IRepository<User> _repository = new Repository<User>(_context.Users);
        private static readonly UserService _userService = new UserService(_unitOfWork, _userFinder, _repository);


        [HttpPost]
        [Route("User/CreateUser/")]
        public IHttpActionResult CreateUser(UserModel user)
        {
            var mappedUser = UserMapping.Map(user);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_userService.CreateUser(mappedUser));
        }

        [HttpDelete]
        [Route("User/DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            var userToDelete = _userService.GetUserById(id).FirstOrDefault();

            if (userToDelete == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _userService.DeleteUser(userToDelete);
        }
        
        [HttpGet]
        [Route("User/Count/")]
        public int Count() => _userService.GetAllUsers().Count;

        [HttpGet]
        [Route("User/ById/{id}")]
        public IHttpActionResult ById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("User/AllUsers")]
        public IHttpActionResult AllUsers() => Ok(_userService.GetAllUsers());

        [HttpGet]
        [Route("User/ByReg/{date}")]
        public IHttpActionResult ByReg(DateTime date)
        {
            var user = _userService.GetUsersByRegDate(date);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        
    }
}
