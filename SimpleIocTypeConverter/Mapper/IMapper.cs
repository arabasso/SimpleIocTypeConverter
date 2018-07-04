using System.Threading.Tasks;

namespace SimpleIocTypeConverter.Mapper
{
    public interface IMapper
    {
        Task<TDestiny> MapAsync<TDestiny>(object source);
    }
}
