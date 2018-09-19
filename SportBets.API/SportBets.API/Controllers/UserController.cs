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
using SportBets.DAL.EntitiesContext;

namespace SportBets.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly SportBetsContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserFinder _userFinder;
        private readonly IRepository<User> _repository;
        private readonly IUserService _userService;

        public UserController(SportBetsContext context,
                              IUnitOfWork unitOfWork,
                              IUserFinder userFinder,
                              IRepository<User> repository,
                              IUserService userService)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _userFinder = userFinder;
            _repository = repository;
            _userService = userService;
        }

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
