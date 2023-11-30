using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FileDetails : BaseEntity
    {
        public byte[] FileData { get; set; }
        public string FileName { get; set; }

    }
}
