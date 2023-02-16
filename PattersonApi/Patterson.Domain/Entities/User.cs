using Patterson.Domain.Common;
using System;
using System.Collections.Generic;

namespace Patterson.Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public List<Form> Forms { get; set; }
    }
}