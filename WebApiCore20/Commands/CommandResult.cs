using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore20.Commands
{
    public class CommandResult
    {
        private CommandResult() { }

        private CommandResult(string failureReason)
        {
            FailureReason = failureReason;
        }

        public string FailureReason { get; }
        public bool IsSuccess => string.IsNullOrEmpty(FailureReason);

        public static CommandResult Success()
        {
            return new CommandResult();
        }

        public static CommandResult Failure(string reason)
        {
            return new CommandResult(reason);
        }

        public static implicit operator bool(CommandResult result)
        {
            return result.IsSuccess;
        }
    }

    public class CommandResult<T>
    {
        private CommandResult() { }

        private CommandResult(string failureReason)
        {
            FailureReason = failureReason;
        }

        private CommandResult(T result)
        {
            Result = result;
        }

        public string FailureReason { get; }
        public T Result { get; }
        public bool IsSuccess => string.IsNullOrEmpty(FailureReason);

        public static CommandResult<T> Success()
        {
            return new CommandResult<T>();
        }

        public static CommandResult<T> Success(T result)
        {
            return new CommandResult<T>(result);
        }

        public static CommandResult<T> Fail(string reason)
        {
            return new CommandResult<T>(reason);
        }

        public static implicit operator bool(CommandResult<T> result)
        {
            return result.IsSuccess;
        }
    }
}
