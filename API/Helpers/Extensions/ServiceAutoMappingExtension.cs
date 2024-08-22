using AutoMapper;
using Bussines.Mappings;

namespace Helpers.Extensions
{
    public static class ServiceAutoMappingExtension
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(item =>
            {
                item.AddProfile(new ConfigurationMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}

