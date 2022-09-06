using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordCounter.src.mod
{
    public class Word
    {
        public int Id { get; }
        public string Value { get; set; }
        public int Count { get; set; }

        public Word(int id, string value, int count)
        {
            Id = id;
            Value = value;
            Count = count;
        }
    }
}
