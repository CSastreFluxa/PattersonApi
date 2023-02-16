using System;

namespace Patterson.Domain.ViewModel
{
    public class FormFieldViewModel
    {
        public Guid Id { get; set; }
        public Guid FormId { get; set; }
        public Guid FieldId { get; set; }
        public FieldViewModel Field { get; set; }
        public string Answer { get; set; }
    }
}