using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Abstractions
{
    public interface IUnitOfWork
    {
        FirebaseAuthProvider AuthProvider { get; }
        IRepository<Models.User> UserRepository { get; }
        IRepository<Tour> TourRepository { get; }
    }
}
