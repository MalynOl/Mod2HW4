using System;
using Autofac;

namespace HomeWork8
{
    internal class Starter
    {
        private readonly IAction _action;
        private readonly ILogger _log;

        public Starter(IAction action, ILogger log)
        {
            _action = action;
            _log = log;
        }

        internal void Run()
        {
            bool result = true;
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    int typeActionMethod = new Random().Next(1, 4);

                    switch (typeActionMethod)
                    {
                        case 1:
                            result = _action.StartMethod();
                            break;
                        case 2:
                            result = _action.SecondMethod();
                            break;
                        case 3:
                            result = _action.ThirdMethod();
                            break;
                    }
                }
                catch (BusinessException be)
                {
                    _log.LoggerWarning($"Action got this custom Exception: ", be);
                }
                catch (Exception ex)
                {
                    _log.LoggerError($"Action failed by a reason: ", ex);
                }
            }

            _log.WriteLogsToFile(_log.AllLogs);
        }
    }
}
