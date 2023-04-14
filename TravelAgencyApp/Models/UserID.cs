using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.Models
{
    public class UserID
    {
        private string _email;
        private string _password;
        private ReservationBook _reservationBook;

        public UserID(string email,string password, ReservationBook reservationBook)
        {
            _email = email;
            _password = password;
            _reservationBook = reservationBook;
        }

        public UserID() { }

        public string Email {
            get { return _email; } 
            set { _email = value; }
        }
        public string Password { 
            get { return _password; }
            set { _password = value; }
        }
    }
}
