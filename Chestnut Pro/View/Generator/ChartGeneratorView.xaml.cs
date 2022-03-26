namespace Chestnut_Pro.View
{
    using Chestnut_Pro.Model;
    using Chestnut_Pro.ViewModel;
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

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


        async void InitializeAsync()
        {
            await chartView.EnsureCoreWebView2Async(null);
        }

        private void DisplayChart(object sender, RoutedEventArgs e)
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
                string text = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/Data/template.html");
                chartView.CoreWebView2.NavigateToString(text.Replace("%%data%%", data.ToString()));
            }
        }

        private void SelectAll(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ChartGeneratorViewModel;
            var checkbox = sender as CheckBox;

            if (vm != null)
            {
                foreach (var item in vm.Data)
                {
                    if (checkbox?.IsChecked ?? true)
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }
            }
        }

        private void ClearAll(object sender, RoutedEventArgs e)
        {
            SourceData.ItemsSource = new ObservableCollection<ChartModel>();
            ((CheckBox)sender).IsChecked = false;
        }


        private void DoubleClickDeleteRow(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as ChartGeneratorViewModel;
            if (vm != null)
            {
                var chart = SourceData.SelectedItem as ChartModel;
                vm.Data.Remove(chart);
            }
        }
    }
}
