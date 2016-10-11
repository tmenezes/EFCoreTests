using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.Logging;

namespace EFCore.Repository.Infra
{
    public class MyLoggerProvider : ILoggerProvider
    {
        private readonly string[] _categories =
        {
            typeof(RelationalCommandBuilderFactory).FullName,
            typeof(SqlServerConnection).FullName
        };

        public ILogger CreateLogger(string categoryName)
        {
            if (_categories.Contains(categoryName))
            {
                return new MyLogger();
            }

            return new NullLogger();
        }

        public void Dispose()
        {
        }


        private class MyLogger : ILogger
        {
            private readonly string _logFileName;

            public MyLogger()
            {
                _logFileName = Path.Combine(Path.GetTempPath(), "EFCoreTestsLog.txt");
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                var log = formatter(state, exception);
                var dateInfo = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                var threadId = Thread.CurrentThread.ManagedThreadId.ToString("000");
                var logText = $"{dateInfo} [{threadId}] {GetLogLevelName(logLevel)} - {log}\n";

                File.AppendAllText(_logFileName, logText);
                Console.WriteLine(logText);
                Debug.WriteLine(logText);
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }


            private string GetLogLevelName(LogLevel logLevel)
            {
                switch (logLevel)
                {
                    case LogLevel.Trace:
                        return "Trace";
                    case LogLevel.Debug:
                        return "Debug";
                    case LogLevel.Information:
                        return "Info ";
                    case LogLevel.Warning:
                        return "Warn ";
                    case LogLevel.Error:
                        return "Error";
                    case LogLevel.Critical:
                        return "Crit ";
                    default:
                        return "None ";
                }
            }
        }

        private class NullLogger : ILogger
        {
            public bool IsEnabled(LogLevel logLevel)
            {
                return false;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}