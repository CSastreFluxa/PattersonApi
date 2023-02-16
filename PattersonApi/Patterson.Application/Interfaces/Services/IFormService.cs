using Patterson.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterson.Application.Interfaces.Services
{
    public interface IFormService
    {
        Task<IEnumerable<FormViewModel>> GetFormsAsync(Guid userId);
        Task<FormViewModel> GetFormAsync(Guid formId);
    }
}