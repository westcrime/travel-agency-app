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

        public IFirebaseClient Client;

        public DatabaseService()
        {
            try
            {
                Client = new FirebaseClient(ifc);

            }
            catch
            {
                throw new NoInternetException();
            }
        }
    }
}
