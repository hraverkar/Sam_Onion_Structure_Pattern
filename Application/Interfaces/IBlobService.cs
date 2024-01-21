using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBlobService
    {
        public string SaveFileIntoBlob(string fileName, byte[] Content);
    }
}
