namespace Chestnut_Pro.View
{
    using Chestnut_Pro.Model;
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

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
            SouceData.ItemsSource = LoadCollectionData();
        }
        async void InitializeAsync()
        {
            await chartView.EnsureCoreWebView2Async(null);
            if (chartView != null && chartView.CoreWebView2 != null)
            {
                string text = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/Data/test.html");
                chartView.CoreWebView2.NavigateToString(text);
            }
        }

        private List<ChartModel> LoadCollectionData()
        {
            List<ChartModel> dataSource = new List<ChartModel>() {
                new ChartModel("Brazil", "Portugal", 5),
                new ChartModel("Brazil", "France", 1),
                new ChartModel("Brazil", "Spain", 1),
                new ChartModel("Brazil", "England", 1),
                new ChartModel("Canada", "Portugal", 1),
                new ChartModel("Canada", "France", 5),
                new ChartModel("Canada", "England", 1),
                new ChartModel("Mexico", "Portugal", 1),
                new ChartModel("Mexico", "France", 1),
            };

            return dataSource;
        }
    }
}
