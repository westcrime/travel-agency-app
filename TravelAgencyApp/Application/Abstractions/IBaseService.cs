using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Application.Abstractions
{
    public interface IBaseService<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(string id);
        Task AddAsync(T item);
        Task DeleteAsync(T item);
    }
}
