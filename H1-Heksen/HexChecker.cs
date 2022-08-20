using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H1_Heksen
{
    public enum HexValidity
    {
        INCORRECT_LENGTH,
        MISSING_HASH,
        INVALID_INPUT,
        VALID
    }

    /// <summary>
    /// Tool to check if a string input is a valid hexadecimal color value (#000000-#FFFFFF).
    /// </summary>
    internal class HexChecker
    {
        public HexValidity Check(string input)
        {
            // If the input doesn't start with #
            if (!HasHash(input[0]))
            {
                return HexValidity.MISSING_HASH;
            }

            // If the input is an incorrect length
            if (!IsCorrectLength(input))
            {
                return HexValidity.INCORRECT_LENGTH;
            }

            // If the input contains characters other than 0-9, A-F
            if (!HasOnlyValidCharacters(input.Substring(1)))
            {
                return HexValidity.INVALID_INPUT;
            }

            return HexValidity.VALID; // Input string passed all tests
        }

        private bool IsCorrectLength(string input)
        {
            return input.Length == 7; // All hexadecimal color values must be exactly 7 characters long.
        }

        private bool HasHash(char input)
        {
            return (input == '#');
        }

        private bool HasOnlyValidCharacters(string input)
        {
            Regex regHex = new Regex("[0-F]"); // Regular expression used to check if all characters fall within the 0-F range.

            return regHex.IsMatch(input);
        }
    }
}
