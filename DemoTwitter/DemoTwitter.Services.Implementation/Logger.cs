using System;
using log4net;
using System.ComponentModel.Composition;
using System.Linq;
using DemoTwitter.Infrastructure.Helpers;
using log4net.Appender;
using log4net.Core;

namespace DemoTwitter.Services.Implementation
{
    [Export(typeof(ILog))]
    public class Logger : ILog
    {
        private readonly log4net.ILog netLog;
        private readonly Type type;

        public Logger()
        {
            type = typeof(Logger);
            netLog = LogManager.GetLogger(Constants.CommonLoggerName);
        }

        #region ILog members
        public void Debug(string message)
        {
            Log(message, Level.Debug);
        }

        public void Info(string message)
        {
            Log(message, Level.Info);
        }

        public void Warn(string message)
        {
            Log(message, Level.Warn);
        }

        public void Error(string message)
        {
            Log(message, Level.Error);
        }

        public void Fatal(string message)
        {
            Log(message, Level.Fatal);
        }

        public void Debug(string message, Exception t)
        {
            Log(message, Level.Debug, t);
        }

        public void Info(string message, Exception t)
        {
            Log(message, Level.Info, t);
        }

        public void Warn(string message, Exception t)
        {
            Log(message, Level.Warn, t);
        }

        public void Error(string message, Exception t)
        {
            Log(message, Level.Error, t);
        }

        public void Fatal(string message, Exception t)
        {
            Log(message, Level.Fatal, t);
        }
        #endregion

        public string GetLogFilePath()
        {
            var filePath = LogManager.GetRepository().GetAppenders()
                             .OfType<FileAppender>()
                             .FirstOrDefault()?.File ?? string.Empty;
            return filePath;
        }

        private void Log(string message, Level level)
        {
            Log(message, level, null);
        }

        private void Log(string message, Level level, Exception t)
        {
            netLog.Logger.Log(type, level, message, t);
        }
    }
}
