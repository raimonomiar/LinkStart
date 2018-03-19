using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkStart.Core;
using LinkStart.Core.ViewModels;

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
                Roles = _unitOfWork.RoleRepository.GetRoles()
            };

            return View(model);
        }
    }
}