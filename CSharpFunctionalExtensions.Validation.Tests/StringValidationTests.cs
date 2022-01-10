using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Validation.Tests
{
    public class StringValidationTests
    {
        [Fact]
        public void Null_String_With_No_Name_Should_Return_False_With_Message()
        {
            var str = (string)null;

            var validationResult = str.IsNotNull().Validate();

            validationResult.IsFailure.Should().BeTrue();
            validationResult.Error.Should().Be(GenericValidation.FailureReasons.ProvidedValueWasNull());
        }

        [Fact]
        public void IfCheckingStringParseableToGuid_Should_Return_Both_Null_Error_And_UnparseableToGuidError()
        {
            var str = (string)null;

            var validationResult = str.IsNotNull().IsParseableToGuid().Validate();

            validationResult.IsFailure.Should().BeTrue();
            validationResult.Error.Should().Contain(GenericValidation.FailureReasons.ProvidedValueWasNull());
            validationResult.Error.Should().Contain(StringValidation.FailureReasons.CantParseStringToGuid(str));
        }
    }
}
