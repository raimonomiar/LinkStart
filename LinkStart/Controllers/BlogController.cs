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
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Blog
        public async Task<ActionResult> Index()
        {
            var blogViewModel = new PostViewModel
            {
                PostList = await _unitOfWork.PostRepository.GetPostList()
            };

            return View(blogViewModel);
        }
    }
}