namespace Chestnut_Pro.View
{
    using Chestnut_Pro.Service;
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for TSVCSVConverterView.xaml
    /// </summary>
    public partial class TSVCSVView : UserControl
    {
        private const string TSV = ".tsv";
        private const string CSV = ".csv";

        public TSVCSVView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Browse TSV file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseTSVFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var file = openFileDialog.FileName;
                if (Path.GetExtension(file) == TSV)
                {
                    TSV_File_Text_Box.Text = file;
                    TSV_File_Text_Box.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Browse CSV file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseCSVFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var file = openFileDialog.FileName;
                if (Path.GetExtension (file) == CSV)
                {
                    CSV_File_Text_Box.Text= file;
                    CSV_File_Text_Box.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// TSV CSV File Convert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSVCSVFileConvert(object sender, RoutedEventArgs e)
        {
            try
            {
                var tsvFile = TSV_File_Text_Box.Text;
                var csvFile = CSV_File_Text_Box.Text;
                List<string> outputLines = new List<string>();
                var outputFolder = string.Empty;
                var outputFile = string.Empty;

                if (!string.IsNullOrEmpty(tsvFile))
                {
                    outputFolder = Path.GetDirectoryName(tsvFile) + "\\";
                    outputFile = Path.GetFileNameWithoutExtension(tsvFile) + CSV;
                    foreach (var line in FileUtils.GetFileContent(tsvFile))
                    {
                        outputLines.Add(line.Replace("\t",","));
                    }
                }
                else if (!string.IsNullOrEmpty(csvFile))
                {
                    outputFolder = Path.GetDirectoryName(csvFile) + "\\";
                    outputFile = Path.GetFileNameWithoutExtension(csvFile) + TSV;
                    foreach (var line in FileUtils.GetFileContent(tsvFile))
                    {
                        outputLines.Add(line.Replace(",", "\t"));
                    }
                }

                FileUtils.WriteTextToFile(outputFolder, outputFile, outputLines);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// TSV CSV Text Convert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSVCSVTextConvert(object sender, RoutedEventArgs e)
        {
            try
            {
                var tsvText = TSV_Text_Box.Text;
                var csvText = CSV_Text_Box.Text;
                if (!string.IsNullOrEmpty(tsvText))
                {
                    csvText = tsvText.Replace("\t", ",");
                    CSV_Text_Box.Text = csvText;
                }
                else if (!string.IsNullOrEmpty(csvText))
                {
                    tsvText = csvText.Replace(",", "\t");
                    TSV_Text_Box.Text = tsvText;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
