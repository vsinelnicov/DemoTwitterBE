using System;
using System.Reflection;

namespace DemoTwitter.Infrastructure.Helpers
{
    public class Constants
    {
        public const string CommonLoggerName = "CommonLogger";
        private static readonly Version Version = Assembly.GetExecutingAssembly().GetName().Version;
    }
}
