using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnWebAPI.Service
{
    public class CreditCardService
    {
        /// <summary>
        /// Validates a credit card number using the Luhn algorithm.
        /// From Right to Left, 
        /// if Odd Index Number, sum up the digit, 
        /// if Even Index Number, multiply by 2 and sum up digits ( if more than 9, sum up those digits first), check All zeros
        /// </summary>
        /// <param name="cardNumber">The credit card number as a string.</param>
        /// <returns>True if the card number is valid, otherwise false.</returns>
        public static bool IsValid(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber) || !cardNumber.All(char.IsDigit) || (cardNumber.Trim('0').Length == 0))
                return false;

            int sum = 0;
            bool isEven = false;

            // Iterate through the card number from right to left
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = cardNumber[i] - '0'; // Convert char to int

                // If even, double the digit
                if (isEven)
                {
                    digit *= 2;

                    // If the result is greater than 9, subtract 9 (Same like if more than 9, add those digits eg. 10 = 1, 11=2)
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
                isEven = !isEven; // Toggle Even for next digit
            }

            // A valid card number will have a sum divisible by 10
            return (sum % 10) == 0;
        }
    }
}
