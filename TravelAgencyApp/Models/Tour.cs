using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.Models
{
    public class Tour
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Price")]
        public string Price { get; set; }
        [JsonProperty(PropertyName = "Picture")]
        public string Picture { get; set; }

        public Tour()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
