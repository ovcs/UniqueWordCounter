using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueWordCounter.src.mod;

namespace UniqueWordCounter.src.io
{
    internal interface ITextSerializator
    {
        public InnerData Deserialize(string raw);
        public string Serialize(InnerData innerData);
    }
}
