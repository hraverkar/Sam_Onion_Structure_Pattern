﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
