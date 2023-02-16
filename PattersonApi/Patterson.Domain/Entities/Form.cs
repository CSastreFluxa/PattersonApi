using Patterson.Domain.Common;
using System;
using System.Collections.Generic;

namespace Patterson.Domain.Entities
{
    public class Form : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public List<FormField> FormFields { get; set; }
    }
}