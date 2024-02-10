using Domain.Common;

namespace Domain.Entities
{
    public class ClassTable : BaseEntity
    {
        public string ClassName { get; set; }
        public string Section { get; set; }
        public bool IsDeleted { get; set; }

    }
}
