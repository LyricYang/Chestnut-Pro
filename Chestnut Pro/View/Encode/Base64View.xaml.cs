namespace Chestnut_Pro.View
{
    using System;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    public partial class Base64View : UserControl
    {
        public Base64View()
        {
            InitializeComponent();
        }

        private void Base64InputClear(object sender, RoutedEventArgs e)
        {
            Base64Output_Box.Text = string.Empty;
            Base64Input_Box.Text = string.Empty;
        }

        private void Base64Convert(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Encode_Button.IsChecked ?? false)
                {
                    var bytes = Encoding.UTF8.GetBytes(Base64Input_Box.Text);
                    Base64Output_Box.Text = Convert.ToBase64String(bytes);
                }
                else
                {
                    var bytes = Convert.FromBase64String(Base64Input_Box.Text);
                    Base64Output_Box.Text = Encoding.UTF8.GetString(bytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
