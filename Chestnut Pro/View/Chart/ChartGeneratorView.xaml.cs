namespace Chestnut_Pro.View
{
    using Chestnut_Pro.Model;
    using Chestnut_Pro.ViewModel;
    using System;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.IO;

    /// <summary>
    /// Interaction logic for DownloadView.xaml
    /// </summary>
    public partial class ChartGeneratorView : UserControl
    {
        /// <summary>
        /// The Constructor
        /// </summary>
        public ChartGeneratorView()
        {
            InitializeComponent();
            InitializeAsync();
        }

        /// <summary>
        /// Initialize WebView2
        /// </summary>
        async void InitializeAsync()
        {
            await chartView.EnsureCoreWebView2Async(null);
        }

        /// <summary>
        /// Display Chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayChart(object sender, RoutedEventArgs e)
        {
            try
            {
                var items = SourceData.Items.SourceCollection;
                var data = new StringBuilder();
                foreach (var item in items)
                {
                    var row = item as ChartModel;
                    if (row.Visible)
                    {
                        data.AppendLine($"['{row.Source}', '{row.Destination}', {row.Value}],");
                    }
                }

                if (chartView != null && chartView.CoreWebView2 != null)
                {
                    string text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/Data/template.html");
                    text = text.Replace("%%data%%", data.ToString())
                        .Replace("%%chart-width%%", ChartWidth.Text)
                        .Replace("%%chart-height%%", ChartHeight.Text)
                        .Replace("%%width%%", NodeWidth.Text)
                        .Replace("%%name%%", $"'{FontName.Text}'")
                        .Replace("%%size%%", FontSize.Text)
                        .Replace("%%node%%", NodePad.Text)
                        .Replace("%%label%%", LabelPad.Text)
                        .Replace("%%bold%%", NodeBold.IsChecked ?? false ? "true" : "false")
                        .Replace("%%italic%%", NodeItalic.IsChecked ?? false ? "true" : "false");

                    chartView.CoreWebView2.NavigateToString(text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Double click to delete row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleClickDeleteRow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vm = DataContext as ChartGeneratorViewModel;
                if (vm != null)
                {
                    var chart = SourceData.SelectedItem as ChartModel;
                    vm.Data.Remove(chart);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}