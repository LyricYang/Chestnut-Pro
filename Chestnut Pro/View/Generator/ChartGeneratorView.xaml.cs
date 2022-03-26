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
    using Microsoft.Win32;
    using System.Windows.Input;
    using System.IO;
    using Chestnut_Pro.Service;

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
                string text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/Data/template.html");
                text = text.Replace("%%data%%", data.ToString())
                    .Replace("%%width%%", NodeWidth.Text)
                    .Replace("%%name%%", $"'{FontName.Text}'")
                    .Replace("%%size%%", FontSize.Text)
                    .Replace("%%node%%", NodePad.Text)
                    .Replace("%%label%%", LabelPad.Text)
                    .Replace("%%bold%%", NodeBold.IsChecked?? false ? "true" : "false")
                    .Replace("%%italic%%", NodeItalic.IsChecked?? false ? "true" : "false");

                chartView.CoreWebView2.NavigateToString(text);
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

        private void BrowseFile(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    var file = openFileDialog.FileName;
                    if (Path.GetExtension(file) == ".csv")
                    {
                        FilePath.Text = file;
                        var source = new ObservableCollection<ChartModel>();
                        foreach (var row in FileUtils.GetFileContent(file))
                        {
                            var cols = row.Split(',');
                            source.Add(new ChartModel()
                            {
                                Source = cols[0],
                                Destination = cols[1],
                                Value = Convert.ToInt32(cols[2]),
                                Visible = true,
                            });
                        }
                        var vm = DataContext as ChartGeneratorViewModel;
                        vm.Data = source;
                        SourceData.ItemsSource = vm.Data;
                    }
                    else
                    {
                        MessageBox.Show("Please upload csv file!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
