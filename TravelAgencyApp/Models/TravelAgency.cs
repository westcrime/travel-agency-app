using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.Models
{
    public class TravelAgency
    {
        private readonly User _currentUser;

        public TravelAgency(User user)
        {
            _currentUser = user;
        }
    }
}
