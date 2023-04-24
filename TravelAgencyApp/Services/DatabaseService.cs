using System.Text.RegularExpressions;
using FireSharp;
using TravelAgencyApp.Exceptions;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Services
{
    public class DatabaseService
    {
        private IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "vA1E2KXr5BWbzpKr4HJdY6OTfJOCcBP0jZQyH5nJ",
            BasePath = "https://mauitravelagencyapp-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        private IFirebaseClient client;

        public DatabaseService()
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

        public async Task AddTourAsync(Tour tour)
        {
            await client.SetAsync("Tours/" + tour.Id, tour);
        }

        public async Task RemoveTourAsync(Tour tour)
        {
            await client.DeleteAsync("Tours/" + tour.Id);
        }

        public async Task<List<Tour>> GetToursAsync()
        {
            FirebaseResponse response = await client.GetAsync("Tours/");
            var mList = JsonConvert.DeserializeObject<IDictionary<string, Tour>>(response.Body);
            if (mList == null)
                return null;
            return mList.Values.ToList();
        }

        public async Task<Tour> GetTourAsync(string id)
        {
            FirebaseResponse response = await client.GetAsync("Tours/" + id);
            return JsonConvert.DeserializeObject<Tour>(response.Body);
        }

        public async Task AddUserAsync(User user)
        {
            await client.SetAsync("Users/" + user.Id, user);
        }

        public async Task<User> GetUserAsync(string id)
        {
            FirebaseResponse response = await client.GetAsync("Users/" + id); 
            var user = JsonConvert.DeserializeObject<User>(response.Body);
            return user;
        }
    }
}
