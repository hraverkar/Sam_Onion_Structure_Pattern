using System;

namespace Domain.Dtos
{
    public class ClassDto
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
