using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordCounter.src.mod.rep
{
    internal interface IRepository<T>
    {
        public void Add(T obj);
        public int GetIDBy(T obj);

        public List<T> GetAll();
        public T GetBy(int ID);
        public T Search(string value);

        public InnerData Serialize();
        public void Remove(T obj);
    }
}
