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
        private TourID _tourID;

        public Reservation(double price, TourID tourID) 
        {
            _timeOfReservation = DateTime.Now;
            _price = price;
            _tourID = tourID;
        }
    }
}
