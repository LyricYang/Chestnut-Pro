using Chestnut_Pro.Service;
namespace Chestnut_Pro.View
{
    using ICSharpCode.AvalonEdit.Folding;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    public partial class JsonFormatterView : UserControl
    {
        FoldingManager foldingManager;

        public JsonFormatterView()
        {
            InitializeComponent();
            InitializeAvalonEditor();
        }

        private void InitializeAvalonEditor()
        {
            JsonInput_Box.ShowLineNumbers = true;
            JsonOutput_Box.ShowLineNumbers = true;
            foldingManager = FoldingManager.Install(JsonOutput_Box.TextArea);
            var foldingStrategy = new BraceFoldingStrategy();
            DispatcherTimer foldingUpdateTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(2),
            };
            foldingUpdateTimer.Tick += (o,args) => foldingStrategy.UpdateFoldings(foldingManager, JsonOutput_Box.Document);
            foldingUpdateTimer.Start();
        }

        private void JsonFormat(object sender, RoutedEventArgs e)
        {
            var json = JsonInput_Box.Text;
            if (!string.IsNullOrEmpty(json) && JsonHelper.IsValid(json))
            {
                JsonOutput_Box.Text = JsonHelper.Format(json, (Indentation)JsonFormatComboBox.SelectedIndex);
            }
        }
    }
}
