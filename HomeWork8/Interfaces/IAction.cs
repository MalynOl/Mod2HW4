namespace HomeWork8
{
    internal interface IAction
    {
        public Logger Instance { get; }

        public bool StartMethod();

        public bool SecondMethod();

        public bool ThirdMethod();
    }
}
