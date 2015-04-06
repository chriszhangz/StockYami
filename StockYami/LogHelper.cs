using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace StockYami
{
    class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("LogInfo");

        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("LogError");
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteErrorLog(Type t, Exception ex)

        public static void WriteErrorLog(Type t, Exception ex)
        {
            logerror.Error("Error", ex);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteErrorLog(Type t, string msg)

        public static void WriteErrorLog(string msg)
        {
            logerror.Error(msg);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteInfoLog(Type t, string msg)

        public static void WriteLog(Type t, string msg)
        {
            loginfo.Info(msg);
        }

        #endregion
    }
}
