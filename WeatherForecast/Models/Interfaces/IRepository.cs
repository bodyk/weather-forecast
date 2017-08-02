using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Models.Interfaces
{
    interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Get(string name);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Clear();
    }
}
