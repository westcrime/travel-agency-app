using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.Models
{
    public class Tour
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Picture { get; set; }

        public Tour()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
