using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClassRoom : BaseEntity
    {
        public int Year { get; set; }
        public Grade Grade { get; set; }
        public Guid GradeId { get; set; }
        public string Section { get; set; }
        public bool Status { get; set; }
        public string Remarks { get; set; }
        public Teacher Teacher { get; set; }
        public Guid TeacherId { get; set; }
    }
}
