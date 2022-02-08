using System;
using System.Reflection;

namespace HomeWork8
{
    internal class Action : IAction
    {
        private readonly ILogger _log;

        public Action(ILogger log)
        {
            _log = log;
        }

        public bool StartMethod()
        {
            _log.LoggerInfo($"Start method: {nameof(StartMethod)}");
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
