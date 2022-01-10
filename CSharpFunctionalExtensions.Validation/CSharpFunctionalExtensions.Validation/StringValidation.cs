using System;
using System.Collections.Generic;

namespace CSharpFunctionalExtensions.Validation
{
    public static class StringValidation
    {
        public static ValidationCollection<string> IsParseableToGuid(this ValidationCollection<string> vc)
        {
            vc.Validations.Add(IsParseableToGuid());
            return vc;
        }

        public static ValidationCollection<string> IsParseableToGuid(this string str) => 
            new ValidationCollection<string>()
            {
                Value = str,
                Validations = new List<Func<string, Result<string>>>()
                {
                    IsParseableToGuid()
                }
            };

        private static Func<string, Result<string>> IsParseableToGuid() =>
            new Func<string, Result<string>>(x =>
             {
                 return Guid.TryParse(x, out var result)
                 ? Result.Success(x)
                 : Result.Failure<string>(FailureReasons.CantParseStringToGuid(x));
             });

        public static class FailureReasons
        {
            public static string CantParseStringToGuid(string str) => $"string '{str}' could not be parsed to a GUID";
        }
    }
}
