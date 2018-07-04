using System;
using System.Threading.Tasks;

namespace SimpleIocTypeConverter.Mapper
{
    public class Mapper
        : IMapper
    {
        private readonly IServiceProvider _serviceProvider;

        public Mapper(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TDestiny> MapAsync<TDestiny>(
            object source)
        {
            var typeConverter = typeof(ITypeConverter<,>);

            var type = typeConverter.MakeGenericType(source.GetType(), typeof(TDestiny));

            var s = _serviceProvider.GetService(type);

            var method = s.GetType().GetMethod("ConvertAsync", new[]
            {
                source.GetType()
            });

            return await (Task<TDestiny>)method.Invoke(s, new[]
            {
                source
            });
        }
    }
}
