using System.Diagnostics.CodeAnalysis;
using ProductJudgeAPI.Exceptions;

namespace ProductJudgeAPI.Extensions
{
    public static class Ensure
    {
        /// <summary>
        /// Ensures that the given expression is true
        /// </summary>
        /// <exception cref="Exception">Exception thrown if false condition</exception>
        /// <param name="condition">Condition to test/ensure</param>
        /// <param name="message">Message for the exception</param>
        /// <exception cref="Exception">Thrown when <paramref name="condition"/> is false</exception>
        public static void That(bool condition, ExceptionMessagesConstants message = null!)
        {
            if (condition) return;
            var volunteeringException = new ProductJudgeException(ExceptionMessagesConstants.Create(
                message.Code,
                message.Message));

            throw volunteeringException;
        }

        public static void NotNull<T>(T? obj, ExceptionMessagesConstants message) where T : class
        {
            if (obj is null)
            {
                var exception = new ProductJudgeException(ExceptionMessagesConstants.Create(
                    message.Code,
                    message.Message));

                throw exception;
            }
        }
    }
}