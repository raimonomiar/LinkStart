using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkStart.Core;
using LinkStart.Persistence;
using Microsoft.AspNet.Identity;

namespace LinkStart.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
       

        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }

       
    }
}