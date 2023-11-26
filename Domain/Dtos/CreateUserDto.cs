﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class CreateUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}