namespace ProductJudgeAPI.Exceptions
{
    public class ExceptionMessagesConstants
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public static readonly ExceptionMessagesConstants UserNotFound = new("11", UserNotFoundMessage);
        public const string UserNotFoundMessage = "Usuario/a no encontrado en base de datos.";

                public static readonly ExceptionMessagesConstants ProductNotFound = new("11", ProductNotFoundMessage);
        public const string ProductNotFoundMessage = "Producto no encontrado en base de datos.";

        public static readonly ExceptionMessagesConstants InvalidCredentials = new("404", InvalidCredentialsMessage);
        public const string InvalidCredentialsMessage = "Credenciales incorrectos";

        public static readonly ExceptionMessagesConstants EmailRegistered = new("404", EmailRegisteredMessage);
        public const string EmailRegisteredMessage = "Ese correo ya esta registrado en el sistema.";

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