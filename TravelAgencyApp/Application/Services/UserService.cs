using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.Abstractions;
using TravelAgencyApp.Application.Abstractions;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Application.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        FirebaseAuthProvider IUserService.AuthProvider => _unitOfWork.AuthProvider;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Models.User item)
        {
            await _unitOfWork.UserRepository.AddAsync(item);
        }

        public async Task DeleteAsync(Models.User item)
        {
            await _unitOfWork.UserRepository.DeleteAsync(item);
        }

        public async Task<List<Models.User>> GetAllAsync()
        {
            return await _unitOfWork.UserRepository.ListAllAsync();
        }

        public async Task<Models.User> GetAsync(string id)
        {
            return await _unitOfWork.UserRepository.GetAsync(id);
        }
    }
}
