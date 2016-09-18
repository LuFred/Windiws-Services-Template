using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class LogHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Error(string errMsg)
        {
            logger.Error(errMsg);
        }
        public static void Debug(string debugMsg)
        {
            logger.Debug(debugMsg);
        }
        public static void Info(string InfoMsg)
        {
            logger.Info(InfoMsg);
        }
    }
}
