namespace Chestnut_Pro.Views
{
    using Chestnut_Pro.Service;
    using ICSharpCode.AvalonEdit.Folding;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    public partial class XmlFormatterView : UserControl
    {
        FoldingManager foldingManager;

        public XmlFormatterView()
        {
            InitializeComponent();
            InitializeAvalonEditor();
        }

        /// <summary>
        /// Initialize Avalon Editor
        /// </summary>
        private void InitializeAvalonEditor()
        {
            XMLInput_Box.ShowLineNumbers = true;
            XMLOutput_Box.ShowLineNumbers = true;
            foldingManager = FoldingManager.Install(XMLOutput_Box.TextArea);
            var foldingStrategy = new XmlFoldingStrategy();
            DispatcherTimer foldingUpdateTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(2),
            };
            foldingUpdateTimer.Tick += (o,args) => foldingStrategy.UpdateFoldings(foldingManager, XMLOutput_Box.Document);
            foldingUpdateTimer.Start();
        }

        /// <summary>
        /// XML formatter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XMLFormat(object sender, RoutedEventArgs e)
        {
            Warning_Message.IsActive = false;
            var xml = XMLInput_Box.Text;
            var newLine = XMLNewLine?.IsChecked ?? true;
            if (!string.IsNullOrEmpty(xml) && XmlHelper.IsValid(xml))
            {
                XMLOutput_Box.Text = XmlHelper.Format(xml, (Indentation)XMLIndentation.SelectedIndex, newLine);
            }
            else
            {
                Warning_Message.IsActive = true;
                Warning_Message.Message.Content = "wrong format!";
            }
        }

        /// <summary>
        /// Copy Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyContent(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(XMLOutput_Box.Text);
        }

        /// <summary>
        /// XML clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XMLClear(object sender, RoutedEventArgs e)
        {
            XMLInput_Box.Text = string.Empty;
            XMLOutput_Box.Text = string.Empty;
        }
    }
}
