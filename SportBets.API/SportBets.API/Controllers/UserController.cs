using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
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
            private readonly UserService _userService = new UserService(_unitOfWork, _userFinder, _repository);

            [HttpGet]
            public int Count() => _userService.GetAllUsers().Count;

            [HttpGet]
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
            public IHttpActionResult AllUsers() => Ok(_userService.GetAllUsers());

            //TODO: How to use this action correctly?
            [HttpGet]
            public IHttpActionResult ByReg(DateTime date)
            {
                var user = _userService.GetUsersByRegDate(date);
                if (user == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return Ok(user);
            }
            
            [HttpPost]
            public IHttpActionResult CreateUser(UserModel user)
            {
                UserMapping.Map();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _userService.CreateUser(user);
                
                return Ok(user);
            }

            [HttpDelete]
            public void DeleteUser(int id)
            {
                var userToDelete = _userService.GetUserById(id).FirstOrDefault();

                if (userToDelete == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                _userService.DeleteUser(userToDelete);
            }
    }
}
