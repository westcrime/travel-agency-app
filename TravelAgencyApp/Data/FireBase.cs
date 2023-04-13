using TravelAgencyApp.Exceptions;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace TravelAgencyApp.Data
{
    class StudentProfile
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }
    internal class FireBase
    {
        private IFirebaseClient _client;

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "vA1E2KXr5BWbzpKr4HJdY6OTfJOCcBP0jZQyH5nJ",
            BasePath = "https://mauitravelagencyapp-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        public FireBase()
        {
            try
            {
                StudentProfile studentProfile = new StudentProfile
                {
                    Firstname = "John",
                    Lastname = "Doe",
                    Age = 18
                };

                _client = new FirebaseClient(ifc);
                _client.Set("Students/" + "1" + "/StudentProfile", studentProfile);
            }
            catch
            { 
                throw new NoInternetException();
            }
        }
    }
}
