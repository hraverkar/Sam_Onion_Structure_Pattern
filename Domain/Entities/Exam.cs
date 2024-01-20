using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exam : BaseEntity
    {
        public Guid ExamTypeId { get; set; }
        public ExamType ExamType { get; set; }
        public string ExamName { get; set; }
        public string ExamDescription { get; set; }
        public DateTime StartDate { get; set; }
    }
}
