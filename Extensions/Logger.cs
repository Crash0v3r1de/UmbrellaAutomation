using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbrellaAutomation.Extensions
{
    public static class Logger
    {
        private static string LogDir = "Logs\\";

        private static bool LogFolderPresent()
        {
            if (Directory.Exists(LogDir)) return true;
            else
            {
                try
                {
                    Directory.CreateDirectory(LogDir);
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.LogCritical("Failed to create log folder! - this is most likely a useless attempt to log");
                    return false;
                }
            }

        }

        private static void LogCritical(string msg)
        {
            LogFolderPresent();
            using (StreamWriter file = File.AppendText("Critical-"+("MM-dd-yyyy") + ".log"))
            {
                file.WriteLine(msg);
            }
            new MailSender().SendMail(msg);
        }

        private static void AppendLogItem(string msg)
        {
            LogFolderPresent();
            using (StreamWriter file = File.AppendText(LogDir + DateTime.Today.ToString("MM-dd-yyyy")+".log"))
            {
                file.WriteLine(msg);
            }
        }

        public static void LogInfo(string msg)
        {
            LogFolderPresent();
            AppendLogItem($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm")} | Info - {msg}");
        }

        public static void LogWarning(string msg)
        {
            LogFolderPresent();
            AppendLogItem($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm")} | Warning! - {msg}");
        }

        public static void LogError(string msg)
        {
            LogFolderPresent();
            AppendLogItem($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm")} | ERROR! - {msg}");
            new MailSender().SendMail(msg);
        }
    }
}
