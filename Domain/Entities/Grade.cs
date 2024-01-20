using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Grade : BaseEntity
    {
        public string GradeName { get; set; }
        public string GradeDescription { get; set; }
    }
}
