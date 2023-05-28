using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetAsync(string id);

        Task<List<T>> ListAllAsync();

        Task AddAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
