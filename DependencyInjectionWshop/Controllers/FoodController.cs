using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionWshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionWshop.Controllers
{
    public class FoodController : Controller
    {
        private readonly AppData appData;

        public FoodController(AppData appData)
        {
            this.appData = appData;
        }

        public IActionResult Index()
        {
            ViewData["photos"] = appData.Food;

            // to highlight "Food" as the selected menu-item
            ViewData["Is_Food"] = "bold_menu";

            // use sessionId to determine if user has already logged in
            string sessionId = Request.Cookies["sessionId"];
            if (sessionId != null)
            {
                User user = appData.Users.Find(x => x.SessionId == sessionId);
                if (user == null)
                    return RedirectToAction("Index", "Logout");

                ViewData["sessionId"] = sessionId;
                ViewData["likes"] = user.Likes;
            }

            return View("ImageGallery");
        }
    }
}
