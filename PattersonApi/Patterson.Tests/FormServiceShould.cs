using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patterson.Application.Services;
using Patterson.Domain.Interfaces.Repositories;
using Patterson.Domain.ViewModel;
using Patterson.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace Patterson.Tests
{
    public class FormServiceShould
    {
        private readonly IServiceProvider serviceProvider;

        public FormServiceShould()
        {
            var services = new ServiceCollection();

            var myConfiguration = new Dictionary<string, string>
            {
                {"ConnectionStrings:usersDbConnection", "InMemoryNewRoot"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();

            services.AddPersistence(configuration);

            serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task GetAllFormsFromUser()
        {
            var formRepository = serviceProvider.GetService<IFormRepository>();
            var formService = new FormService(formRepository);

            var userRepository = serviceProvider.GetService<IUserRepository>();
            await InsertInitialUserDataAsync(userRepository);

            var result = await formService.GetFormsAsync(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            var expectedResult = GetFormsData();

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetForm()
        {
            var formRepository = serviceProvider.GetService<IFormRepository>();
            var formService = new FormService(formRepository);

            var userRepository = serviceProvider.GetService<IUserRepository>();
            await InsertInitialUserDataAsync(userRepository);

            var result = await formService.GetFormAsync(Guid.Parse("81a130d2-502f-4cf1-a376-63edeb000e9f"));

            var expectedResult = GetFormData();

            result.Should().BeEquivalentTo(expectedResult);
        }

        private static async Task InsertInitialUserDataAsync(IUserRepository userRepository)
        {
            var initialUsersData = GetUsersData();

            foreach (var user in initialUsersData)
            {
                await userRepository.InsertAsync(user);
            }
        }

        private static IEnumerable<UserViewModel> GetUsersData()
        {
            var users = new List<UserViewModel>
            {
                GetUserData()
            };

            return users;
        }

        private static UserViewModel GetUserData()
        {
            return new UserViewModel()
            {
                Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "TestName",
                Forms = GetFormsData().ToList()
            };
        }

        private static IEnumerable<FormViewModel> GetFormsData()
        {
            var forms = new List<FormViewModel>
            {
                GetFormData()
            };

            return forms;
        }

        private static FormViewModel GetFormData()
        {
            return new FormViewModel()
            {
                Id = Guid.Parse("81a130d2-502f-4cf1-a376-63edeb000e9f"),
                Title = "TestForm",
                UserId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                FormFields = new List<FormFieldViewModel>()
                {
                    new FormFieldViewModel()
                    {
                        Id = Guid.Parse("e12eb6b4-2a81-4625-8927-fa17084c1a16"),
                        Field = new FieldViewModel() {
                            Id = Guid.Parse("cdf6a570-9f0a-4d2f-b975-90f6fff822d5"),
                            Question = "TestQuestion?"
                        },
                        FieldId = Guid.Parse("cdf6a570-9f0a-4d2f-b975-90f6fff822d5"),
                        FormId = Guid.Parse("81a130d2-502f-4cf1-a376-63edeb000e9f"),
                        Answer = "TestAnswer"
                    }
                }
            };
        }
    }
}