namespace HomeWork8
{
    public class BusinessException : Exception
    {
        public BusinessException(string exMessage)
            : base(exMessage)
        {
            ExceptionText = exMessage;
        }

        public string ExceptionText { get; set; }
    }
}
