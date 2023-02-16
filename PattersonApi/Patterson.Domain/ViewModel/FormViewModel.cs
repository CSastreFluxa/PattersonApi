using System;
using System.Collections.Generic;

namespace Patterson.Domain.ViewModel
{
    public class FormViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public List<FormFieldViewModel> FormFields { get; set; }
    }
}