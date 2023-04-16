using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.Models
{
    public class Reservation
    {
        private DateTime _timeOfReservation;
        private Double _price;
        private Tour _tourID;

        public Reservation(double price, Tour tourID) 
        {
            _timeOfReservation = DateTime.Now;
            _price = price;
            _tourID = tourID;
        }
    }
}
