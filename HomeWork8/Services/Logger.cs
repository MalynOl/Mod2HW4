using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    public class Logger : ILogger
    {
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;

        private StringBuilder _sbLogs;

        public Logger(IFileService fileService, INotificationService notification)
        {
            _fileService = fileService;
            _notificationService = notification;

            _sbLogs = new StringBuilder();
        }

        public string AllLogs => _sbLogs.ToString();

        public void LoggerInfo(string messageLog)
        {
            LoggerSet(TypeLog.Info, messageLog);
        }

        public void LoggerWarning(string messageLog, BusinessException e)
        {
            LoggerSet(TypeLog.Warning, messageLog + e.ToString());
        }

        public void LoggerError(string messageLog, Exception ex)
        {
            LoggerSet(TypeLog.Error, messageLog + ex.ToString());
        }

        public void LoggerSet(TypeLog tl, string mes)
        {
            var log = $"{DateTime.Now.ToString()}: {tl.ToString()}: {mes.ToString()}\n";
            _sbLogs.Append(log);
            _notificationService.WriteText(log);
        }

        public void WriteLogsToFile(string allLogs)
        {
            _fileService.WriteToFile(allLogs);
        }
    }
}
