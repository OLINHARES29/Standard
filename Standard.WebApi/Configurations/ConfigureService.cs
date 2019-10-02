using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Standard.Framework.Data.Options;

namespace Standard.WebApi.Configurations
{
    public static class ConfigureServices
    {
        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FirebaseClientOptions>(options =>
            {
                configuration.GetSection("FirebaseClientOptions").Bind(options);
                options.CallTokenFactory();
            });
        }
    }
}