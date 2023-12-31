﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<FileDetails> Files { get; set; }
        DbSet<UserAttendanceDetails> UserAttendances { get; set; }
        DbSet<ClassTable> Classes { get; set; }
        Task<int> SaveChangesAsync();
    }
}
