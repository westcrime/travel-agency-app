using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.Models
{
    public class User
    {
        private string _email;
        private string _password;
        public string Id;
        private List<string> _reservationBook;

        public User(string email,string password)
        {
            _email = email;
            _password = password;
            _reservationBook = new List<string>();
        }

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public void AddTourToBook(Tour tour)
        {
            _reservationBook.Add(tour.Id);
        }

        public void RemoveTourFromBook(Tour tour)
        {
            _reservationBook.Remove(tour.Id);
        }

        public event System.EventHandler UserPropertiesChanged;

        public string Email {
            get { return _email; }
            set
            {
                _email = value;
                UserPropertiesChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public string Password { 
            get { return _password; }
            set
            {
                _password = value;
                UserPropertiesChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
