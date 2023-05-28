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
    internal class TourService : ITourService
    {
        private IUnitOfWork _unitOfWork;

        public TourService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Tour item)
        {
            await _unitOfWork.TourRepository.AddAsync(item);
        }

        public async Task DeleteAsync(Tour item)
        {
            await _unitOfWork.TourRepository.DeleteAsync(item);
        }

        public async Task<List<Tour>> GetAllAsync()
        {
            return await _unitOfWork.TourRepository.ListAllAsync();
        }

        public async Task<Tour> GetAsync(string id)
        {
            return await _unitOfWork.TourRepository.GetAsync(id);
        }
    }
}
