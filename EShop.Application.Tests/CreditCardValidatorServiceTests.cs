using EShop.Application;
using Xunit;

namespace EShop.Application.Tests
{
    public class CreditCardValidatorServiceTests
    {
        private readonly CreditCardValidatorService _service = new CreditCardValidatorService();

        [Theory]
        [InlineData("4111 1111 1111 1111", true, "Visa")]
        [InlineData("5500-0000-0000-0004", true, "MasterCard")]
        [InlineData("340000000000009", true, "American Express")]
        [InlineData("6011000000000004", true, "Discover")]
        [InlineData("3530111333300000", true, "JCB")]
        [InlineData("30000000000004", true, "Diners Club")]
        [InlineData("6759649826438453", true, "Maestro")]
        public void Validate_ValidCards_ReturnsCorrectCardType(string cardNumber, bool expectedValid, string expectedType)
        {
            var result = _service.Validate(cardNumber);

            Assert.Equal(expectedValid, result.IsValid);
            Assert.Equal(expectedType, result.CardType);
        }

        [Theory]
        [InlineData("1234 5678 9012 3456")]
        [InlineData("1111 2222 3333 4444")]
        [InlineData("abcd efgh ijkl mnop")]
        [InlineData("4111 1111 1111")]
        [InlineData("")]
        public void Validate_InvalidCards_ReturnsInvalid(string cardNumber)
        {
            var result = _service.Validate(cardNumber);

            Assert.False(result.IsValid);
            Assert.Null(result.CardType);
        }

        [Theory]
        [InlineData("  4111-1111-1111-1111  ", true, "Visa")]
        [InlineData("5500000000000004", true, "MasterCard")]
        public void Validate_TrimmedAndFormattedInputs_AreHandledCorrectly(string cardNumber, bool expectedValid, string expectedType)
        {
            var result = _service.Validate(cardNumber);

            Assert.Equal(expectedValid, result.IsValid);
            Assert.Equal(expectedType, result.CardType);
        }
    }
}