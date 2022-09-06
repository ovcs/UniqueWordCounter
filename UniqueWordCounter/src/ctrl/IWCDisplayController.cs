using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordCounter.src.ctrl
{
    internal interface IWCDisplayController
    {
        public void AllContentResult();
        public void Errors();
        public void Info();
        public void LoadedFile();
    }
}
