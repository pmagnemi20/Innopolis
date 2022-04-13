using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace Homework1.Logging
{
    public static class DbLoggerExtensions
    {
        public static ILoggingBuilder AddDbLogger(this ILoggingBuilder builder, Action<DbLoggerConfiguration> configure)
        {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, DbLoggerProvider>());

            LoggerProviderOptions.RegisterProviderOptions<DbLoggerConfiguration, DbLoggerProvider>(builder.Services);
            builder.Services.Configure(configure);

            return builder;
        }
    }
}
