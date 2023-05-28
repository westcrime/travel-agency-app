using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Application.Abstractions
{
    public interface IUserService : IBaseService<Models.User>
    {
        FirebaseAuthProvider AuthProvider { get; }
    }
}
