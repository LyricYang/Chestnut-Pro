namespace Chestnut_Pro.View
{
    using Chestnut_Pro.Service;
    using System;
    using System.Globalization;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for PictureView.xaml
    /// </summary>
    public partial class ColorPaletteView : UserControl
    {
        public ColorPaletteView()
        {
            InitializeComponent();
        }

        private void ColorButton0000(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0000.ToolTip.ToString();
            ShowHexColor(hex);
        }

        /// <summary>
        /// RGB Convert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RGBConvert(object sender, System.Windows.RoutedEventArgs e)
        {
            var type = (ColorType) Color_InputType_Box.SelectedIndex;
            switch (type)
            {
                default:
                case ColorType.RGB:
                    {
                        var r = Convert.ToInt32(RGB_BOX_R.Text ?? "0");
                        var g = Convert.ToInt32(RGB_BOX_G.Text ?? "0");
                        var b = Convert.ToInt32(RGB_BOX_B.Text ?? "0");

                        // Hex
                        var HexText = $"#{r:X2}{g:X2}{b:X2}";

                        // HLS
                        RGBColorConverter.RGBToHSL(r, g, b, out var h, out var s, out var l);
                        var HLSText = $"{h:0.00},{s:P},{l:P}";

                        // CMYK
                        (var cyan, var magenta, var yellow, var black) = RGBColorConverter.RGBToCMYK(r, g, b);

                        // Output
                        Hex_Copy.Text = HexText;
                        Palette_Card.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
                        Color_Text.Text = HexText;
                        Color_Text.Visibility = System.Windows.Visibility.Visible;
                        HSL_Copy.Text = HLSText;
                        CMYK_Copy.Text = $"{cyan * 100:0.00},{magenta * 100:0.00},{yellow * 100:0.00},{black * 100:0.00}";
                        break;
                    }
                case ColorType.HEX:
                    {
                        var Hex = Hex_Copy.Text.Trim('#');
                        var r = int.Parse(Hex.Substring(0, 2), NumberStyles.AllowHexSpecifier);
                        var g = int.Parse(Hex.Substring(2, 2), NumberStyles.AllowHexSpecifier);
                        var b = int.Parse(Hex.Substring(4, 2), NumberStyles.AllowHexSpecifier);

                        // HLS
                        RGBColorConverter.RGBToHSL(r, g, b, out var h, out var s, out var l);
                        var HLSText = $"{h:0.00},{s:P},{l:P}";

                        // CMYK
                        (var cyan, var magenta, var yellow, var black) = RGBColorConverter.RGBToCMYK(r, g, b);

                        // Output
                        RGB_BOX_R.Text = r.ToString();
                        RGB_BOX_G.Text = g.ToString();
                        RGB_BOX_B.Text = b.ToString();
                        Palette_Card.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
                        Color_Text.Text = Hex_Copy.Text;
                        Color_Text.Visibility = System.Windows.Visibility.Visible;
                        HSL_Copy.Text = HLSText;
                        CMYK_Copy.Text = $"{cyan * 100:0.00},{magenta * 100:0.00},{yellow * 100:0.00},{black * 100:0.00}";
                        break;
                    }
                case ColorType.HSL:
                    {
                        // TO-DO
                        break;
                    }
                case ColorType.CMYK:
                    {
                        // TO-DO
                        break;
                    }
            }
        }

        private void ShowHexColor(string HexStr)
        {
            {
                var Hex = HexStr.Trim('#');
                var r = int.Parse(Hex.Substring(0, 2), NumberStyles.AllowHexSpecifier);
                var g = int.Parse(Hex.Substring(2, 2), NumberStyles.AllowHexSpecifier);
                var b = int.Parse(Hex.Substring(4, 2), NumberStyles.AllowHexSpecifier);

                // HLS
                RGBColorConverter.RGBToHSL(r, g, b, out var h, out var s, out var l);
                var HLSText = $"{h:0.00},{s:P},{l:P}";

                // CMYK
                (var cyan, var magenta, var yellow, var black) = RGBColorConverter.RGBToCMYK(r, g, b);

                // Output
                RGB_BOX_R.Text = r.ToString();
                RGB_BOX_G.Text = g.ToString();
                RGB_BOX_B.Text = b.ToString();
                Palette_Card.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
                Color_Text.Text = HexStr;
                Hex_Copy.Text = HexStr;
                Color_Text.Visibility = System.Windows.Visibility.Visible;
                HSL_Copy.Text = HLSText;
                CMYK_Copy.Text = $"{cyan * 100:0.00},{magenta * 100:0.00},{yellow * 100:0.00},{black * 100:0.00}";
            }
        }
    }
}
