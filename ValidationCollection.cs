using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionalExtensions.Validation
{
    public class ValidationCollection<T>
    {
        internal T Value { get; set; }

        internal List<Func<T,Result<T>>> Validations;

        public Result<T> Validate()
        {
            var result = Result.Combine(
                Validations.Select(x => x(Value)),
                ",");

            return result.IsSuccess
                ? Result.Success(Value)
                : Result.Failure<T>(result.Error);
        }
    }
}
