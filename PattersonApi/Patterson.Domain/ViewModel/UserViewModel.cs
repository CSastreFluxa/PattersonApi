using System;
using System.Collections.Generic;

namespace Patterson.Domain.ViewModel
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<FormViewModel> Forms { get; set; }
    }
}