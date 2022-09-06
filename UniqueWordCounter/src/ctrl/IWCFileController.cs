using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordCounter.src.ctrl
{
    internal interface IWCFileController
    {
        public void SaveResultAs(string path, string fileFormat);
        public void LoadFile(string path);
        public void Calc();
    }
}
