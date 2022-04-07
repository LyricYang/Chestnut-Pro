namespace Chestnut_Pro.View
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DownloadView.xaml
    /// </summary>
    public partial class HashGeneratorView : UserControl
    {
        private readonly MD5 md5 = MD5.Create();
        private readonly SHA1 sha1 = SHA1.Create();
        private readonly SHA256 sha256 = SHA256.Create();
        private readonly SHA512 sha512 = SHA512.Create();
        /// <summary>
        /// The Constructor
        /// </summary>
        public HashGeneratorView()
        {
            InitializeComponent();
        }

        private void CalculateHash(object sender, RoutedEventArgs e)
        {
            var input = SourceInput.Text;
            var bytesInput = Encoding.UTF8.GetBytes(input);
            if (OutputTypeSelected.SelectedIndex == 0)
            {
                MD5Output.Text = Convert.ToHexString(md5.ComputeHash(bytesInput));
                SHA1Output.Text = Convert.ToHexString(sha1.ComputeHash(bytesInput));
                SHA256Output.Text = Convert.ToHexString(sha256.ComputeHash(bytesInput));
                SHA512Output.Text = Convert.ToHexString(sha512.ComputeHash(bytesInput));
            }
            else
            {
                MD5Output.Text = Convert.ToBase64String(md5.ComputeHash(bytesInput));
                SHA1Output.Text = Convert.ToBase64String(sha1.ComputeHash(bytesInput));
                SHA256Output.Text = Convert.ToBase64String(sha256.ComputeHash(bytesInput));
                SHA512Output.Text = Convert.ToBase64String(sha512.ComputeHash(bytesInput));
            }
        }

        private void ClearSource(object sender, RoutedEventArgs e)
        {
            SourceInput.Text = string.Empty;
        }
    }
}
