using System;
using System.Collections.Generic;

namespace CSharpFunctionalExtensions.Validation
{
    public static class GenericValidation
    {
        public static ValidationCollection<T> IsNotNull<T>(this T argument) =>
            new ValidationCollection<T>()
            {
                Value = argument,
                Validations = new List<Func<T, Result<T>>>()
                {
                    IsNotNullFunc<T>()
                }
            };

        private static Func<T, Result<T>> IsNotNullFunc<T>() => new Func<T, Result<T>>(x =>
        {
            return x == null
            ? Result.Failure<T>(FailureReasons.ProvidedValueWasNull())
            : Result.Success(x);
        });

        public static class FailureReasons
        {
            public static string ProvidedValueWasNull() => $"A Value was provided that should not have been null.";
        }
    }
}
