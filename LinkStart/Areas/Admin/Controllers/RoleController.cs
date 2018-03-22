﻿using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using LinkStart.Core;
using LinkStart.Core.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LinkStart.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            var model = new RoleViewModel
            {
                Roles = _unitOfWork.RoleRepository.GetRoles(),

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RoleViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Roles = _unitOfWork.RoleRepository.GetRoles();

                    TempData["Danger"] = String.Join("--",
                        ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));
                    return View(model);
                }

                var role = new IdentityRole
                {
                    Name = model.RoleName
                };

                _unitOfWork.RoleRepository.Add(role);

                _unitOfWork.Complete();



                TempData["Success"] = $"Role Added !";


            }
            catch (DbEntityValidationException e)
            {
                TempData["Danger"] =
                    $"Oops.. Something went wrong {String.Join("--", e.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage))}";
            }
            catch (Exception ex)
            {
                TempData["Danger"] = $"Oops.. Something went wrong {ex.Message}";

            }


            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var role = _unitOfWork.RoleRepository.GetSingleRole(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            var model = new RoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                Roles = _unitOfWork.RoleRepository.GetRoles()
            };

            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoleViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Roles = _unitOfWork.RoleRepository.GetRoles();

                    TempData["Danger"] = String.Join("--", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));

                    return View("Index",model) ;
                }

                var role = new IdentityRole
                {
                    Id = model.Id,
                    Name = model.RoleName,

                };

                _unitOfWork.RoleRepository.Update(role);

                _unitOfWork.Complete();

                TempData["Success"] = "Role Updated !";
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

            model.Roles = _unitOfWork.RoleRepository.GetRoles();
            return View("Index", model);
        }

        public ActionResult Delete(string id)
        {
            var role = _unitOfWork.RoleRepository.GetSingleRole(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            _unitOfWork.RoleRepository.Delete(role);

            _unitOfWork.Complete();

            TempData["Success"] = "Role Deleted !";

            return RedirectToAction("Index");
        }
    }
}