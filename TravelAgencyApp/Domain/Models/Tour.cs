using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.Models
{
    public class Tour : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Picture { get; set; }

        public Tour()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Tour(string name, string description, string price, string picture)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Price = price;
            Picture = picture;
        }
    }
}
