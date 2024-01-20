using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Attendance: BaseEntity
    {
        public DateTime Date { get; set; }
        public Student Student { get; set; }
        public Guid StudentId { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; }
    }
}
