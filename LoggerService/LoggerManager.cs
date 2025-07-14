using Contracts;
using NLog;

namespace Dot_Net_Core_Web_APIs
{
    public class LoggerManager : ILoggerManager
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {
        }

        public void LogInformation(string message) => logger.Info(message);
        public void LogWarning(string message) => logger.Warn(message);
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
    }
}
