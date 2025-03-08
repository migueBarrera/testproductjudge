namespace ProductJudgeAPI.Exceptions
{
    public class ExceptionMessagesConstants
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public static readonly ExceptionMessagesConstants UserNotFound = new("11", UserNotFoundMessage);
        public const string UserNotFoundMessage = "Usuario/a no encontrado en base de datos.";

        public static readonly ExceptionMessagesConstants InvalidCredentials = new("404", InvalidCredentialsMessage);
        public const string InvalidCredentialsMessage = "Credenciales incorrectos";

        private ExceptionMessagesConstants(string code)
        {
            Code = code;
            Message = string.Empty;
        }

        private ExceptionMessagesConstants(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static ExceptionMessagesConstants Create(string code, string message)
        {
            return new(code, message);
        }
    }
}