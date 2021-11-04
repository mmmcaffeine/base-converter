namespace Dgt.BaseConverter
{
    public static class Calculator
    {
        public static (int Quotient, int Remainder) Divide(int dividend, int divisor)
        {
            var quotient = 0;
            var remainder = dividend;

            while (remainder >= divisor)
            {
                remainder -= divisor;
                quotient++;
            }

            return (quotient, remainder);
        }
    }
}