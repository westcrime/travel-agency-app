using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelAgencyApp.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "Email")]
        public string Email;
        [JsonProperty(PropertyName = "Balance")]
        public double Balance;
        [JsonProperty(PropertyName = "Password")]
        public string Password;
        [JsonProperty(PropertyName = "Id")]
        public string Id;
        [JsonProperty(PropertyName = "ReservationBook")]
        public List<string> ReservationBook;

        public User(string email,string password, string id)
        {
            Id = id;
            Email = email;
            Password = password;
            ReservationBook = new List<string>();
            Balance = 0.0;
        }

        public User()
        {
            ReservationBook = new List<string>();
            Balance = 0.0;
        }

        public void AddTourToBook(Tour tour)
        {
            ReservationBook.Add(tour.Id);
        }

        public void RemoveTourFromBook(Tour tour)
        {
            ReservationBook.Remove(tour.Id);
        }
    }
}
