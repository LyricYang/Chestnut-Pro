using Chestnut_Pro.Service;
namespace Chestnut_Pro.Views
{
    using ICSharpCode.AvalonEdit.Folding;
    using MaterialDesignThemes.Wpf;
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

        /// <summary>
        /// Initialize Avalon Editor
        /// </summary>
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

        /// <summary>
        /// JSON formatter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JsonFormat(object sender, RoutedEventArgs e)
        {
            Warning_Message.IsActive = false;
            var json = JsonInput_Box.Text;
            if (!string.IsNullOrEmpty(json) && JsonHelper.IsValid(json))
            {
                JsonOutput_Box.Text = JsonHelper.Format(json, (Indentation)JsonFormatComboBox.SelectedIndex);
            }
            else
            {
                Warning_Message.IsActive = true;
                Warning_Message.Message.Content = "wrong format!";
            }
        }

        /// <summary>
        /// JSON clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JsonClear(object sender, RoutedEventArgs e)
        {
            JsonInput_Box.Text = string.Empty;
            JsonOutput_Box.Text = string.Empty;
        }

        /// <summary>
        /// Copy Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyContent(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(JsonOutput_Box.Text);
        }
    }
}
