namespace ProductJudgeAPI.Exceptions
{
    public class ProductJudgeException : ApplicationException
    {
        public string Code { get; private set; }

        public ProductJudgeException(ExceptionMessagesConstants message) : this(message, null) { }

        public ProductJudgeException(ExceptionMessagesConstants message, Exception? inner) : base(message.Message, inner)
        {
            Code = message.Code;
        }
    }
}