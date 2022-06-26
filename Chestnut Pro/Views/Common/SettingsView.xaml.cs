namespace Chestnut_Pro.Views
{
    using System.Diagnostics;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for TSVCSVConverterView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start("rundll32", "url.dll,FileProtocolHandler " + e.Uri.ToString());
        }
    }
}
