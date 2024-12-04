using Xunit;
using LuhnWebAPI.Service;

namespace LuhnWebAPI.Test
{
    public class CreditCardValidationTest
    {
        [Theory]
        [InlineData("4532015112830366", true)] // Valid Card
        [InlineData("1234567890123456", false)] // Invalid Luhn
        [InlineData("0000000000000000", false)] // Invalid (all zeros)
        [InlineData("453201511283036", false)] // Invalid length (14 digits)

        public void IsValid_Result(string cardNumber, bool expected)
        {
            // Act
            var result = CreditCardService.IsValid(cardNumber);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsValid_IsNotNumeric()
        {
            // Arrange
            var invalidCardNumber = "1234abcd5678efgh";

            // Act
            var result = CreditCardService.IsValid(invalidCardNumber);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_EmptyOrNull()
        {
            // Act & Assert
            Assert.False(CreditCardService.IsValid(null));
            Assert.False(CreditCardService.IsValid(string.Empty));
            Assert.False(CreditCardService.IsValid("     "));
        }
    }
}