using FluentResults;

namespace Huginn.Common.Extensions;

public static class ResultExtensions
{
    extension(Result)
    {
        public static Result WithErrorCode(Enum value) => new Result().WithError(value.ToString());
        
        public static Result WithSuccessCode(Enum value) => new Result().WithSuccess(value.ToString());
    }
}
