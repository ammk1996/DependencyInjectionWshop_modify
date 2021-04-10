using System;
using System.Collections.Generic;

namespace DependencyInjectionWshop.Models
{
    public class AppData
    {
        public AppData()
        {
            Users = new List<User>();

            Office = new List<Photo>();
            Travel = new List<Photo>();
            Food = new List<Photo>();
        }

        public List<User> Users { get; set; }

        public List<Photo> Office { get; set; }
        public List<Photo> Travel { get; set; }
        public List<Photo> Food { get; set; }
    }
}


