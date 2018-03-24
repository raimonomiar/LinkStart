using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web.Http;
using AutoMapper;
using LinkStart.Core;
using LinkStart.Core.Dtos;
using LinkStart.Core.Models;
using LinkStart.Core.ViewModels;

namespace LinkStart.Controllers.Api
{
    [AllowAnonymous]
    public class UserController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
            
        [HttpGet]
        public IHttpActionResult GetUsers(string id)
        {
            var user = _unitOfWork.UserRepository.GetSingleUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<User, UserDto>(user));

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



    

    }
}
