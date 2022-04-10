namespace Chestnut_Pro.View
{
    using Figgle;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DownloadView.xaml
    /// </summary>
    public partial class ASCIIArtGeneratorView : UserControl
    {
        /// <summary>
        /// The Constructor
        /// </summary>
        public ASCIIArtGeneratorView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ASCII art generator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ASCIIGenerate(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SourceInput.Text))
            {
                return;
            }

            var setup = @"
------------- ASCII diagrams editor -------------

https://asciiflow.com/#/
https://patorjk.com/software/taag/#p=testall&f=Acrobatic&t=Chestnut%20Pro%20

------------- ASCII Art -------------------------

";
            var ascii = FontSelect.Text switch
            {
                "Alpha" => FiggleFonts.Alpha.Render(SourceInput.Text),
                "Acrobatic" => FiggleFonts.Acrobatic.Render(SourceInput.Text),
                "Avatar" => FiggleFonts.Avatar.Render(SourceInput.Text),
                "Big" => FiggleFonts.Big.Render(SourceInput.Text),
                "Blocks" => FiggleFonts.Blocks.Render(SourceInput.Text),
                "Bulbhead" => FiggleFonts.Bulbhead.Render(SourceInput.Text),
                "Cards" => FiggleFonts.Cards.Render(SourceInput.Text),
                "CatWalk" => FiggleFonts.CatWalk.Render(SourceInput.Text),
                "Doom" => FiggleFonts.Doom.Render(SourceInput.Text),
                "Epic" => FiggleFonts.Epic.Render(SourceInput.Text),
                "Graceful" => FiggleFonts.Graceful.Render(SourceInput.Text),
                "Graffiti" => FiggleFonts.Graffiti.Render(SourceInput.Text),
                "Impossible" => FiggleFonts.Impossible.Render(SourceInput.Text),
                "Isometric3" => FiggleFonts.Isometric3.Render(SourceInput.Text),
                "Merlin1" => FiggleFonts.Merlin1.Render(SourceInput.Text),
                "Modular" => FiggleFonts.Modular.Render(SourceInput.Text),
                "Slant" => FiggleFonts.Slant.Render(SourceInput.Text),
                "Small Slant" => FiggleFonts.SlantSmall.Render(SourceInput.Text),
                "SubZero" => FiggleFonts.SubZero.Render(SourceInput.Text),
                "Sweet" => FiggleFonts.Sweet.Render(SourceInput.Text),
                _ => FiggleFonts.Standard.Render(SourceInput.Text),
            };

            AsciiArtOutput.Text = setup + ascii;
        }

        private void InputClear(object sender, RoutedEventArgs e)
        {
            SourceInput.Text = string.Empty;
        }
    }
}
