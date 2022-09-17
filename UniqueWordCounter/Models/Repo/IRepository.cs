using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordCounter.Models.Repo
{
    internal interface IRepository<T>
    {
        public int Count { get; }
        public void Create(T element, out T createElement);
        public void Delete(T element);
        public List<T> GetAll();
        public bool TryRead(string value, out T element);
        public void Update(T element, T changeparametrs);
    }
}
