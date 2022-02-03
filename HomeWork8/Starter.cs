using Autofac;
namespace HomeWork8
{
    internal class Starter
    {
        private IAction _action;

        public Starter(IAction action)
        {
            _action = action;
            Instance = Logger.GetLog();
        }

        private Logger Instance { get; set; }

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
                    Instance.LoggerWarning($"Action got this custom Exception: ", be);
                }
                catch (Exception ex)
                {
                    Instance.LoggerError($"Action failed by a reason: ", ex);
                }
            }

            DependencyInjection dependencyInjection = new DependencyInjection();
            var container = dependencyInjection.SetDI();
            var writeLog = container.Resolve<Logger>();
            writeLog.WriteLogsToFile(Instance.AllLogs);
        }
    }
}
