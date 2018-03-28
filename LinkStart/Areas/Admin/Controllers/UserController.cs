using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LinkStart.Core;
using LinkStart.Core.Models;
using LinkStart.Core.ViewModels;

namespace LinkStart.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/User
        public async Task<ActionResult > Index()
        {
            var model = new UserViewModel
            {
                Users = await _unitOfWork.UserRepository.GetUsers(),
                RoleList = (await _unitOfWork.RoleRepository.GetRoles()).Select(
                    x=>new SelectListItem
                    {
                        Value = x.Name,
                        Text = x.Name
                    }).ToList()

            };

            return View(model);
        }


      /*  [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Users = _unitOfWork.UserRepository.GetUsers();

                    TempData["Danger"] = String.Join("--", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));

                    return View("Index", model);
                }

                var user = new User
                {
                    Id = model.UserId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.UserName
                };

                _unitOfWork.UserRepository.Update(user);

                _unitOfWork.Complete();

                TempData["Success"] = "User Updated !";

            }
            catch (DbEntityValidationException e)
            {
                TempData["Danger"] =
                    $"Oops.. Something went wrong {String.Join("--", e.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage))}";
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Oops.. Something went wrong {e.Message}";

            }

            model.Users = _unitOfWork.UserRepository.GetUsers();

            return View("Index", model);
        }*/

        //    public ActionResult Assign(string id)
        //    {
        //        var model = new AssignRoleViewModel
        //        {
        //            UserId = id,
        //            RoleList = _unitOfWork.RoleRepository

        //        };
        //    }
    }
}