using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DependencyInjectionWshop.Models;

namespace DependencyInjectionWshop.Util
{
    public class Helper
    {
        public Helper()
        {
        }

        public static AppData InitAppData()
        {
            AppData appData = new AppData();

            AddUsers(appData.Users);
            AddGallery(appData.Office, "office.data");
            AddGallery(appData.Travel, "travel.data");
            AddGallery(appData.Food, "food.data");

            return appData;
        }

        public static void AddUsers(List<User> users)
        {
            string[] names = { "john", "mary" };

            if (users == null)
                return;                      

            foreach (string name in names)
            {
                User user = new User()
                {
                    UserId = Guid.NewGuid().ToString(),
                    Username = name,
                    Password = name
                };

                users.Add(user);
            }
        }

        public static void AddGallery(List<Photo> photos, string filename)
        {
            if (photos == null)
                return;

            string[] lines = File.ReadAllLines("SeedData" + "/" + filename);
            foreach (string line in lines)
            {
                string[] pair = line.Split(";");
                if (pair.Length != 2)
                    continue;   // not what we expected; skip

                Regex regex = new Regex("https://images.unsplash.com/photo-(.*)\\?w=350");
                Match match = regex.Match(pair[0]);
                string photoId = match.Groups[1].ToString();

                Photo photo = new Photo()
                {
                    Id = photoId,
                    Url = pair[0],
                    Tags = new List<string>(pair[1].Split(","))
                };

                photos.Add(photo);                        
            }
        }
    }
}
