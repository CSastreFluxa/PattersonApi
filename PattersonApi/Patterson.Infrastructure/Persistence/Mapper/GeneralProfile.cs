using AutoMapper;
using Patterson.Domain.Entities;
using Patterson.Domain.ViewModel;

namespace Patterson.Infrastructure.Persistence.Mapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Form, FormViewModel>();
            CreateMap<FormViewModel, Form>();

            CreateMap<FormField, FormFieldViewModel>();
            CreateMap<FormFieldViewModel, FormField>();

            CreateMap<Field, FieldViewModel>();
            CreateMap<FieldViewModel, Field>();
        }
    }
}