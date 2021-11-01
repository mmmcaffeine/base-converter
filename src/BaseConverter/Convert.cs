using System;
using System.Collections.Generic;

namespace Dgt.BaseConverter
{
    public static class Convert
    {
        private const int AsciiCodeFor0 = 48;
        private const int AsciiCodeForA = 65;
        
        // TODO Validate value is a hex number
        // TODO Handle negative numbers
        public static int HexToDecimal(string value)
        {
            var decimalNumber = 0;
            var multiplier = 1;
            
            for (var i = value.Length - 1; i >= 0; i--)
            {
                var character = value[i];
                var digit = char.IsDigit(character)
                    ? character - AsciiCodeFor0
                    : character - AsciiCodeForA + 10;
                decimalNumber += digit * multiplier;
                multiplier *= 16;
            }
            
            return decimalNumber;
        }
        
        // TODO Handle negative numbers
        public static string DecimalToHex(int value)
        {
            if (value == 0) return "0";
            
            var quotient = value;
            var chars = new Stack<char>();

            while (quotient > 0)
            {
                quotient = Math.DivRem(quotient, 16, out var remainder);
                var asciiCode = remainder < 10
                    ? remainder + AsciiCodeFor0
                    : remainder + AsciiCodeForA - 10;
                chars.Push((char)asciiCode);
            }

            return new string(chars.ToArray());
        }
    }
}