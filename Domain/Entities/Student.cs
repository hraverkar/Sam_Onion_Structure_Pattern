using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNO { get; set; }
        public Parent Parent { get; set; }
        public Guid ParentId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool Status { get; set; }
        public DateTime LastLogin { get; set; }
        public string LastLoginIP { get; set; }
    }
}
