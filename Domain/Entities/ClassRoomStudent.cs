﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClassRoomStudent : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
