using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using LinkStart.Core;
using LinkStart.Core.Dtos;
using LinkStart.Core.Models;
using LinkStart.Core.ViewModels;
using Microsoft.AspNet.Identity.Owin;

namespace LinkStart.Controllers.Api
{
    [AllowAnonymous]
    public class UserController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        private ApplicationUserManager _userManager;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public UserController(ApplicationUserManager userManager)
        {

            _userManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        public IHttpActionResult GetUsers(string id)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetSingleUser(id);

                if (user == null)
                {
                    return NotFound();
                }


                return Ok(Mapper.Map<User, UserDto>(user));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
    

        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] UserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var user = new User
                {
                    Id = model.UserId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName,
                    PhoneNumber = model.PhoneNumber
                };

                _unitOfWork.UserRepository.Update(user);

                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();

        }

        [HttpPost]

        public async Task<IHttpActionResult> AssignRole([FromBody] RoleViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await UserManager.AddToRoleAsync(model.Id, model.RoleName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();

        }



    

    }
}
