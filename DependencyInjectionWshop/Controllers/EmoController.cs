using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionWshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DependencyInjectionWshop.Controllers
{
    public class EmoController : Controller
    {
        private readonly AppData appData;

        public EmoController(AppData appData)
        {
            this.appData = appData;
        }

        public IActionResult Like([FromBody] Like like)
        {
            string sessionId = Request.Cookies["sessionId"];

            User user = appData.Users.Find(x => x.SessionId == sessionId);
            if (user == null)
                return Json(new { success = false });   // error; no session

            if (like.LikeIt)
            {
                Debug.WriteLine("Like: " + like.LikeIt);

                string id = user.Likes.Find(x => x == like.PhotoId);
                if (id == null)
                    user.Likes.Add(like.PhotoId);
            }
            else
            {
                Debug.WriteLine("Dislike: " + like.PhotoId);
                user.Likes.Remove(like.PhotoId);
            }
                
            return Json(new { success = true });
        }
    }
}
