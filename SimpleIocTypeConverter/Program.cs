using System;
using Microsoft.Extensions.DependencyInjection;
using SimpleIocTypeConverter.Mapper;
using SimpleIocTypeConverter.Models;
using SimpleIocTypeConverter.TypeConverters;

namespace SimpleIocTypeConverter
{
    public static class Program
    {
        public static void Main()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IMapper, Mapper.Mapper>();
            serviceCollection.AddTransient<ITypeConverter<UserViewModel, User>, UserViewModelTypeConverter>();
            serviceCollection.AddTransient<ITypeConverter<User, UserViewModel>, UserTypeConverter>();

            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var mapper = serviceProvider.GetService<IMapper>();

                var viewModel = mapper.MapAsync<UserViewModel>(new User { Id = 1, Name = "Raphael Basso" }).Result;

                Console.WriteLine("Type: {0}, Id: {1}, Name: {2}", viewModel.GetType(), viewModel.Id, viewModel.Name);

                var user = mapper.MapAsync<User>(viewModel).Result;

                Console.WriteLine("Type: {0}, Id: {1}, Name: {2}", user.GetType(), user.Id, user.Name);
            }

            Console.WriteLine("Press any key to continue. . .");
            Console.ReadKey();
        }
    }
}
