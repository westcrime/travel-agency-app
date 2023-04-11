using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.Models
{
    public class UserID
    {
        private readonly string _email;
        private readonly string _username;
        private readonly string _password;
        private readonly ReservationBook _reservationBook;

        public UserID(string email, string username, string password, ReservationBook reservationBook)
        {
            _email = email;
            _username = username;
            _password = password;
            _reservationBook = reservationBook;
        }
    }
}
