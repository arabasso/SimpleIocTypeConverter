using System.Threading.Tasks;
using SimpleIocTypeConverter.Mapper;
using SimpleIocTypeConverter.Models;

namespace SimpleIocTypeConverter.TypeConverters
{
    public class UserViewModelTypeConverter
        : ITypeConverter<UserViewModel, User>
    {
        public async Task<User> ConvertAsync(
            UserViewModel source)
        {
            return await Task.FromResult(new User
            {
                Id = source.Id, Name = source.Name
            });
        }
    }
}
