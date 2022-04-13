namespace Homework1.Logging
{
    public class DbLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly DbLoggerConfiguration _config;
        public DbLogger(string loggerName, DbLoggerConfiguration config)
        {
            _loggerName = loggerName;
            _config = config;
        }

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
           
            var fileName = Path.Combine(Environment.CurrentDirectory, "log.txt");

            //Дозаписываем файл
            var sw = new StreamWriter(fileName, true);
            sw.WriteLine(formatter(state, exception));
            sw.Close();
        }
    }
}
