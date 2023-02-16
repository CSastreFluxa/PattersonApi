using Patterson.Domain.Common;
using System;

namespace Patterson.Domain.Entities
{
    public class Field : BaseEntity<Guid>
    {
        public string Question { get; set; }
    }
}