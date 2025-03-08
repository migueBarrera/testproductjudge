using ProductJudgeAPI.Exceptions;

public class NotFoundException : ProductJudgeException
    {
        public NotFoundException() :
            base(ExceptionMessagesConstants.UserNotFound)
        { }

        public NotFoundException(string message) :
            base(ExceptionMessagesConstants.Create(ExceptionMessagesConstants.UserNotFound.Code, message))
        { }
    }