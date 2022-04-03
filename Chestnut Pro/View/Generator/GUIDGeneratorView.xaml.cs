namespace Chestnut_Pro.View
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DownloadView.xaml
    /// </summary>
    public partial class GUIDGeneratorView : UserControl
    {
        /// <summary>
        /// The Constructor
        /// </summary>
        public GUIDGeneratorView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Copy GUID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GUIDCopy(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(GUIDOutput_Box.Text);
        }

        /// <summary>
        /// Clear output text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GUIDClear(object sender, RoutedEventArgs e)
        {
            GUIDOutput_Box.Text = string.Empty;
        }

        /// <summary>
        /// Generate GUIDs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GUIDGenerate(object sender, RoutedEventArgs e)
        {
            var hyphens = Hyphens_Button.IsChecked ?? true;
            var upper = Uppercase_Button.IsChecked ?? false;
            var count = GUIDCount_Box.SelectedIndex + 1;

            string output = string.Empty;
            for (int i = 0; i < count; i++)
            {
                var guid = Guid.NewGuid().ToString();
                output += guid + "\r\n";
            }
            output = hyphens ? output : output.Replace("-", "");
            output = upper ? output.ToUpper() : output;
            GUIDOutput_Box.Text = output;
        }
    }
}
