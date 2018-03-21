using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkStart.Core;
using LinkStart.Core.ViewModels;

namespace LinkStart.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/User
        public ActionResult Index()
        {
            var model = new UserViewModel
            {
                Users = _unitOfWork.UserRepository.GetUsers()
            };

            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var user = _unitOfWork.UserRepository.GetSingleUser(id);

            if (user==null)
            {
                return HttpNotFound();
            }

            var
        }

    }
}