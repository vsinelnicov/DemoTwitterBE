using System;

namespace DemoTwitter.Services
{
    public interface ILog
    {
        /* Log a message object */
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);

        /* Log a message object and exception */
        void Debug(string message, Exception t);
        void Info(string message, Exception t);
        void Warn(string message, Exception t);
        void Error(string message, Exception t);
        void Fatal(string message, Exception t);

        /// <summary>
        ///     Return the current log file path.
        /// </summary>
        /// <returns>The current log file path.</returns>
        string GetLogFilePath();
    }
}
