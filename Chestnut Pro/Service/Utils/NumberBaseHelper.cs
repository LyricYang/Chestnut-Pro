namespace Chestnut_Pro.Service
{
    using System.Text;

    /// <summary>
    /// Number Base Helper
    /// </summary>
    public class NumberBaseHelper
    {
        /// <summary>
        /// Split String With White Space
        /// </summary>
        /// <param name="number"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string SplitStringByWhiteSpace(string number, int len)
        {
            int remainder = number.Length % len;
            var result = new StringBuilder();
            for (int i = 0; i < number.Length; i++)
            {
                if (i < remainder)
                {
                    result.Append(number[i]);
                }
                else if ((i + 1 - remainder) % len == 0)
                {
                    result.Append(number[i]).Append(' ');
                }
                else
                {
                    if (result.Length == remainder && result.Length != 0)
                    {
                        result.Append(' ');
                    }
                    result.Append(number[i]);
                }
            }
            return result.ToString().Trim();
        }

        /// <summary>
        /// Check Number
        /// </summary>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool CheckNumberValid(string input, NumberBaseType type)
        {
            foreach (char c in input)
            {
                if (!IsValidChar(c, type))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check Char
        /// </summary>
        /// <param name="c"></param>
        /// <param name="baseNumber"></param>
        /// <returns></returns>
        public static bool IsValidChar(char c, NumberBaseType baseNumber)
        {
            switch (baseNumber)
            {
                case NumberBaseType.Binary:
                    if (c is '0' or '1')
                    {
                        return true;
                    }
                    return false;
                case NumberBaseType.Decimal:
                    return char.IsNumber(c);
                case NumberBaseType.Octal:
                    return char.IsNumber(c) &&
                        c is >= '0' and <= '7';
                case NumberBaseType.Hexadecimal:
                    return char.IsNumber(c) ||
                        c >= 'a' && c <= 'f' ||
                        c >= 'A' && c <= 'F';
                default:
                    return true;
            }
        }
    }
}
