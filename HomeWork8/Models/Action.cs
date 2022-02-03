using System.Reflection;
namespace HomeWork8
{
    internal class Action : IAction
    {
        public Logger Instance => Logger.GetLog();

        public bool StartMethod()
        {
            var m = MethodBase.GetCurrentMethod().Name;
            Instance.LoggerInfo($"Start method: {m}");
            return true;
        }

        public bool SecondMethod()
        {
            throw new BusinessException("Skipped logic in method");

            return true;
        }

        public bool ThirdMethod()
        {
            throw new Exception("I broke a logic");

            return false;
        }
    }
}
