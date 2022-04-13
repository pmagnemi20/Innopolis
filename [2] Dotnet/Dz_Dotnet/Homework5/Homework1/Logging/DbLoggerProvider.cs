using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

namespace Homework1.Logging
{
    [ProviderAlias("DbLogging")]
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, DbLogger> _loggers = new();
        private readonly DbLoggerConfiguration _config;

        public DbLoggerProvider(IOptionsMonitor<DbLoggerConfiguration> config)
        {
            _config = config.CurrentValue;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new DbLogger(name, _config));
        }

        public void Dispose() => _loggers.Clear();
    }
}
