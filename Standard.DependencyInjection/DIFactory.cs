using Microsoft.Extensions.DependencyInjection;
using Standard.Application.Abstractions;
using Standard.Application.Concretes;
using Standard.Domain.Abstractions.EntityService;
using Standard.Domain.Concretes.EntityService;
using Standard.Infrastructure.Abstractions;
using Standard.Infrastructure.Concretes;

namespace Standard.DependencyInjection
{
    public static class DIFactory
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IArquivoApplication, ArquivoApplication>();
            services.AddScoped<IArquivoEntityService, ArquivoEntityService>();
            services.AddScoped<ILogRepository, LogRepository>();
            //services.AddScoped<INotificacaoEmailServiceProvider, LogRepository>();
        }
    }
}
