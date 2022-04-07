namespace Chestnut_Pro.View
{
    using Chestnut_Pro.Service;
    using System;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    public partial class NumberBaseView : UserControl
    {
        public NumberBaseView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Convert Number Base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertNumberBase(object sender, RoutedEventArgs e)
        {
            var format = Fromat_Button.IsChecked ?? false;
            var type = (NumberBaseType)NumberTypeBox.SelectedIndex;
            var input = string.IsNullOrEmpty(NumberBase_Input.Text) ? "0" : NumberBase_Input.Text;
            input = input.Replace(" ", "").Replace(",", "");
            if (CheckNumberValid(input, type))
            {
                Warning_Message.IsActive = false;
                var number = type switch
                {
                    NumberBaseType.Binary => Convert.ToInt32(input, 2),
                    NumberBaseType.Octal => Convert.ToInt32(input, 8),
                    NumberBaseType.Hexadecimal => Convert.ToInt32(input, 16),
                    _ => Convert.ToInt32(input),
                };

                Binary_output.Text = format ? SplitStringByWhiteSpace(Convert.ToString(number, 2), 4) : Convert.ToString(number, 2);
                Octal_output.Text = format ? SplitStringByWhiteSpace(Convert.ToString(number, 8), 3) : Convert.ToString(number, 8);
                Decimal_output.Text = format ? string.Format("{0:N0}", number) : Convert.ToString(number);
                Hexadecimal_output.Text = format ? SplitStringByWhiteSpace(Convert.ToString(number, 16), 4) : Convert.ToString(number, 16);
            }
            else
            {
                Warning_Message.IsActive = true;
            }
        }

        /// <summary>
        /// Split String With White Space
        /// </summary>
        /// <param name="number"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private string SplitStringByWhiteSpace(string number, int len)
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

        private bool CheckNumberValid(string input, NumberBaseType type)
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

        private bool IsValidChar(char c, NumberBaseType baseNumber)
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
