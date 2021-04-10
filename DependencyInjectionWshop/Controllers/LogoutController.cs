using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionWshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionWshop.Controllers
{
    public class LogoutController : Controller
    {
        private readonly AppData appData;

        public LogoutController(AppData appData)
        {
            this.appData = appData;
        }

        public IActionResult Index()
        {
            // remove the user's sessionId from our record
            string sessionId = Request.Cookies["sessionId"];
            User user = appData.Users.Find(x => x.SessionId == sessionId);
            if (user != null)
                user.SessionId = null;  // denote user has logged off

            // remove cookie on user's browser
            Response.Cookies.Delete("sessionId");

            // direct user back to our default gallery
            return RedirectToAction("Index", "Office");
        }
    }
}
