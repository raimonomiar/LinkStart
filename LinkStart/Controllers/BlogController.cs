using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LinkStart.Core;
using LinkStart.Core.ViewModels;

namespace LinkStart.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Blog
        public ActionResult Index()
        {
          /*  var blogViewModel = new PostViewModel
            {
                Posts= (await _unitOfWork.PostRepository.GetPostList()).ToPagedList(page ?? 1,5)
            };*/

            return View();
        }
    }
}