using System.Threading.Tasks;

namespace SimpleIocTypeConverter.Mapper
{
    public interface ITypeConverter<in TSource, TDestiny>
    {
        Task<TDestiny> ConvertAsync(TSource source);
    }
}
