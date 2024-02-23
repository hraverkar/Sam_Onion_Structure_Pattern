﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } =  false;

    }
}
