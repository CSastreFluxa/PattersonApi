using Patterson.Application.Interfaces.Services;
using Patterson.Domain.Interfaces.Repositories;
using Patterson.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterson.Application.Services
{
    public class FormService : IFormService
    {
        public IFormRepository FormRepository { get; set; }
        
        public FormService(IFormRepository formRepository)
        {
            this.FormRepository = formRepository;
        }

        public Task<IEnumerable<FormViewModel>> GetFormsAsync(Guid userId)
        {
            return this.FormRepository.GetFormsAsync(userId);
        }

        public Task<FormViewModel> GetFormAsync(Guid formId)
        {
            return this.FormRepository.GetAsync(formId);
        }
    }
}