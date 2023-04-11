using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.Models
{
    public class TravelAgency
    {
        private readonly UserID _currentUser;

        public TravelAgency(UserID user)
        {
            _currentUser = user;
        }
    }
}
