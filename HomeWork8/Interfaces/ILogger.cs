using System;

namespace HomeWork8
{
    public interface ILogger
    {
        public string AllLogs { get; }

        public void LoggerInfo(string messageLog);

        public void LoggerWarning(string messageLog, BusinessException e);

        public void LoggerError(string messageLog, Exception ex);

        public void LoggerSet(TypeLog tl, string mes);

        public void WriteLogsToFile(string allLogs);
    }
}
