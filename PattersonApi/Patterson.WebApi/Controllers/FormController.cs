using Microsoft.AspNetCore.Mvc;
using Patterson.Application.Interfaces.Services;
using Patterson.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterson.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IFormService FormService;

        public FormController(IFormService formService)
        {
            FormService = formService;
        }

        [HttpGet]
        [Route("GetForms")]
        public async Task<IEnumerable<FormViewModel>> GetFormsAsync(Guid userId)
        {
            return await FormService.GetFormsAsync(userId);
        }

        [HttpGet]
        [Route("GetForm")]
        public async Task<FormViewModel> GetUFormAsync(Guid formId)
        {
            return await FormService.GetFormAsync(formId);
        }
    }
}