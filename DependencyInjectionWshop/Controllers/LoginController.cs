using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DependencyInjectionWshop.Models;

namespace DependencyInjectionWshop.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppData appData;

        public LoginController(AppData appData)
        {
            this.appData = appData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticate(string username, string password)
        {
            User user = appData.Users.Find(x => x.Username == username &&
                x.Password == password);

            if (user == null)
            {
                ViewData["username"] = username;
                ViewData["errMsg"] = "No such user or incorrect password.";

                return View("Index");
            }
            else
            {
                user.SessionId = Guid.NewGuid().ToString();
                Response.Cookies.Append("sessionId", user.SessionId);

                return RedirectToAction("Index", "Office");
            }
        }
    }  
}
