using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using log4net.Layout;
using log4net.Core;

namespace WebApiAOP.Helper
{
    public static class Logger
    {
        private static string LogFile;
        private static string LogLevel;
        private static bool VerboseLogging;

        static Logger()
        {
            LogFile = GetLoggingFileProperty();
            LogLevel = GetLogLevelProperty();
        }

        private static string GetLogLevelProperty()
        {
            return LogFile;
        }

        private static string GetLoggingFileProperty()
        {
            return LogLevel;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Setup()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();
            var level = hierarchy.LevelMap[LogLevel] ?? Level.Off;

            var patternLayout = new PatternLayout { ConversionPattern = "%date [%thread] %-6level %logger – %message%exception%newline" };
            patternLayout.ActivateOptions();

            var roller = new RollingFileAppender
            {
                AppendToFile = true,
                File = "C:\\logs\\", //LogFile
                RollingStyle = RollingFileAppender.RollingMode.Composite,
                DatePattern = ".yyyyMMdd",
                MaxSizeRollBackups = 10,
                MaximumFileSize = "1GB",
                StaticLogFileName = true,
                LockingModel = new FileAppender.MinimalLock(),
                Layout = patternLayout,
            };
            roller.ActivateOptions();

            hierarchy.Root.AddAppender(roller);
            hierarchy.Root.Level = level;
            hierarchy.Configured = true;
        }
    }
}