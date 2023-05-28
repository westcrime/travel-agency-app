using FireSharp.Response;
using Newtonsoft.Json;
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
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DatabaseService _client;

        public Repository(DatabaseService client)
        {
            this._client = client;
        }

        public async Task AddAsync(T entity)
        {
            string path = string.Empty;
            if (typeof(T) == typeof(User))
            {
                path = "Users";
            }
            else
            {
                path = "Tours";
            }

            var response = await _client.Client.SetAsync($"{path}/" + entity.Id, entity);
        }

        public async Task DeleteAsync(T entity)
        {
            string path = string.Empty;
            if (typeof(T) == typeof(User))
            {
                path = "Users";
            }
            else
            {
                path = "Tours";
            }

            var response = await _client.Client.DeleteAsync($"{path}/" + entity.Id);
        }

        public async Task<T> GetAsync(string id)
        {
            string path;
            if (typeof(T) == typeof(User))
            {
                path = "Users";
            }
            else
            {
                path = "Tours";
            }
            var response = await _client.Client.GetAsync($"{path}/{id}");
            var item = JsonConvert.DeserializeObject<T>(response.Body);
            return item;
        }

        public async Task<List<T>> ListAllAsync()
        {
            string path;
            if (typeof(T) == typeof(User))
            {
                path = "Users";
            }
            else
            {
                path = "Tours";
            }
            FirebaseResponse response = await _client.Client.GetAsync($"{path}/");
            var mList = JsonConvert.DeserializeObject<IDictionary<string, T>>(response.Body);
            if (mList == null)
                return null;
            return mList.Values.ToList();
        }
    }
}
