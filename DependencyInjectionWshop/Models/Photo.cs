using System;
using System.Collections.Generic;

namespace DependencyInjectionWshop.Models
{
    public class Photo
    {
        public Photo()
        {
            Tags = new List<string>();
        }

        public string Id { get; set; }
        public string Url { get; set; }
        public List<string> Tags { get; set; }
    }
}
