﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class StudentFileUploadDto
    {
        public string FileData { get; set; }
        public string FileName { get; set; }
        public int FileType { get; set; }
    }
}
