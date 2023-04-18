using System.Text.RegularExpressions;
using FireSharp;
using TravelAgencyApp.Exceptions;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Data
{
    public class FireBaseService
    {
        private IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "vA1E2KXr5BWbzpKr4HJdY6OTfJOCcBP0jZQyH5nJ",
            BasePath = "https://mauitravelagencyapp-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        private IFirebaseClient client;

        public FireBaseService()
        {
            try
            {
                client = new FirebaseClient(ifc);
                
            }
            catch
            { 
                throw new NoInternetException();
            }
        }

        public async void AddTourAsync(Tour tour)
        {
            await client.SetAsync("Tours/" + tour.Id, tour);
        }

        public async void AddUserAsync(User user)
        {
            await client.SetAsync("Users/" + user.Id + "/UserInfo", user);
        }

        public async void RemoveTourAsync(Tour tour)
        {
            App.User.RemoveTourFromBook(tour);
            await client.SetAsync("Users/" + App.User.Id, App.User);
            await client.DeleteAsync("Tours/" + tour.Id);
        }

        public async void RemoveUserAsync(User user)
        {
            await client.DeleteAsync("Users/" + user.Id);
        }

        public async void UpdateUserAsync(User user)
        {
            await client.DeleteAsync("Users/" + user.Id);
            await client.SetAsync("Users/" + App.User.Id + "/UserInfo", App.User);
        }   

        public async Task<List<Tour>> GetToursAsync()
        {
            FirebaseResponse response = await client.GetAsync("Tours/");
            var mList = JsonConvert.DeserializeObject<IDictionary<string, Tour>>(response.Body);
            return mList.Values.ToList();
        }

        public Tour GetTour(string id)
        {
            FirebaseResponse response = client.Get("Tours/" + id);
            return JsonConvert.DeserializeObject<Tour>(response.Body);
        }
    }
}
