using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.Abstractions;
using TravelAgencyApp.Models;
using TravelAgencyApp.Services;

namespace TravelAgencyApp.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        FirebaseAuthProvider IUnitOfWork.AuthProvider =>
            new FirebaseAuthProvider(new FirebaseConfig("AIzaSyC0spDZvY5wOLonDHlgZdWxqdNjjmbaNw8"));
        private readonly DatabaseService _client;
        private readonly Lazy<IRepository<Models.User>> _userRepository;
        private readonly Lazy<IRepository<Tour>> _tourRepository;
        public UnitOfWork(DatabaseService context)
        {
            _client = context;
            _userRepository = new Lazy<IRepository<Models.User>>(() =>
                new Repository<Models.User>(_client));
            _tourRepository = new Lazy<IRepository<Tour>>(() =>
                new Repository<Tour>(_client));
        }

        IRepository<Models.User> IUnitOfWork.UserRepository =>
            _userRepository.Value;
        IRepository<Tour> IUnitOfWork.TourRepository =>
            _tourRepository.Value;
    }
}
