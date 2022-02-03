using System.Text;

namespace HomeWork8
{
    public class Logger
    {
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;

        private static readonly Logger Instance = new Logger();
        private StringBuilder _sbLogs;

        static Logger()
        {
        }

        public Logger(IFileService fileService, INotificationService notification)
        {
            _fileService = fileService;
            _notificationService = notification;
        }

        private Logger()
        {
            _sbLogs = new StringBuilder();
        }

        public string AllLogs => _sbLogs.ToString();
        public static Logger GetLog()
        {
                return Instance;
        }

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

            Console.WriteLine(log);
        }

        public void WriteLogsToFile(string allLogs)
        {
            _fileService.WriteToFile(allLogs);
        }
    }
}
