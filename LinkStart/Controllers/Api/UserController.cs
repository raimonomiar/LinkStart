using System;
using System.Net.Http;
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
    [Authorize(Roles = "Admin")]
    public class UserController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ApplicationUserManager _userManager;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public UserController(ApplicationUserManager userManager)
        {

            _userManager = userManager;
        }
        public ApplicationUserManager UserManager => _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

        [HttpGet]
        public async Task<IHttpActionResult>  GetUsers(string id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetSingleUser(id);

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

        [Authorize(Roles = "User,Admin")]
        [HttpPut]
        public async Task<IHttpActionResult>  Update([FromBody] UserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var user = await _unitOfWork.UserRepository.GetSingleUser(model.UserId);

                user.FirstName = model.FirstName;

                user.LastName = model.LastName;

                user.UserName = model.UserName;

                user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;

                user.Email = model.Email;

                _unitOfWork.UserRepository.Update(user);

              await _unitOfWork.Complete();
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

        [HttpDelete]
        public async Task<IHttpActionResult> RemoveUserRole([FromBody] RoleViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                 bool flag = await UserManager.IsInRoleAsync(model.Id, model.RoleName);

                if (flag)
                {
                    await UserManager.RemoveFromRoleAsync(model.Id, model.RoleName);
                }

                else
                {
                    return BadRequest("selected role isnt assigned to the user");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Opppss something went wrong {e.Message}");
            }

            return Ok();
        }





    

    }
}
