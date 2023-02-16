using Patterson.Domain.Common;
using System;

namespace Patterson.Domain.Entities
{
    public class FormField : BaseEntity<Guid>
    {
        public Guid FormId { get; set; }
        public Guid FieldId { get; set; }
        public Field Field { get; set; }
        public string Answer { get; set; }
    }
}