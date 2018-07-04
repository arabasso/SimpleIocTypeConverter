using System.Threading.Tasks;
using SimpleIocTypeConverter.Mapper;
using SimpleIocTypeConverter.Models;

namespace SimpleIocTypeConverter.TypeConverters
{
    public class UserTypeConverter
        : ITypeConverter<User, UserViewModel>
    {
        public async Task<UserViewModel> ConvertAsync(
            User source)
        {
            return await Task.FromResult(new UserViewModel
            {
                Id = source.Id, Name = source.Name
            });
        }
    }
}
