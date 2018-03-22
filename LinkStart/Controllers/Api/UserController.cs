using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web.Http;
using AutoMapper;
using LinkStart.Core;
using LinkStart.Core.Dtos;
using LinkStart.Core.Models;

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

        [HttpGet]
        public IEnumerable<Iden> GetRoles()
        {
            var roles = _unitOfWork.RoleRepository.GetRoles();

            if (roles == null)
            {
                return NotFound();
            }

            return Json(roles);

        }

    }
}
