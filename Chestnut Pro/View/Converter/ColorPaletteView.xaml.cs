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
        private bool handle = true;

        public ColorPaletteView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorPaletteClear(object sender, System.Windows.RoutedEventArgs e)
        {
            RGB_BOX_R.Clear();
            RGB_BOX_G.Clear();
            RGB_BOX_B.Clear();
            Hex_Copy.Clear();
            HSL_Copy.Clear();
            CMYK_Copy.Clear();
            Color_Text.Visibility = System.Windows.Visibility.Hidden;
            Palette_Card.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        /// <summary>
        /// Color Display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorDisplay(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = ((Button)sender).ToolTip.ToString();
            ShowHexColor(hex);
        }

        /// <summary>
        /// RGB Convert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RGBConvert(object sender, System.Windows.RoutedEventArgs e)
        {
            var type = (ColorType)Color_InputType_Box.SelectedIndex;
            try
            {
                switch (type)
                {
                    default:
                    case ColorType.RGB:
                        {
                            var r = Convert.ToInt32(RGB_BOX_R.Text ?? "0");
                            var g = Convert.ToInt32(RGB_BOX_G.Text ?? "0");
                            var b = Convert.ToInt32(RGB_BOX_B.Text ?? "0");
                            ShowRGBColor(r, g, b);
                            break;
                        }
                    case ColorType.HEX:
                        {
                            var Hex = Hex_Copy.Text.ToUpper();
                            ShowHexColor(Hex);
                            break;
                        }
                    case ColorType.HSL:
                        {
                            var HSL = HSL_Copy.Text.Trim().Split(',');
                            ShowHSLColor(Convert.ToDouble(HSL[0]), Convert.ToDouble(HSL[1].TrimEnd('%')) * 0.01, Convert.ToDouble(HSL[2].TrimEnd('%')) * 0.01);
                            break;
                        }
                    case ColorType.CMYK:
                        {
                            var CMYK = CMYK_Copy.Text.Trim().Split(',');
                            ShowCMYKColor(Convert.ToDouble(CMYK[0]) * 0.01, Convert.ToDouble(CMYK[1]) * 0.01, Convert.ToDouble(CMYK[2]) * 0.01, Convert.ToDouble(CMYK[3]) * 0.01);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// RGB => All
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        private void ShowRGBColor(int r, int g, int b)
        {
            // Hex
            var HexText = $"#{r:X2}{g:X2}{b:X2}";

            // HLS
            RGBColorConverter.RGBToHSL(r, g, b, out var h, out var s, out var l);
            var HSLText = $"{h:0.00},{s:P},{l:P}";

            // CMYK
            (var cyan, var magenta, var yellow, var black) = RGBColorConverter.RGBToCMYK(r, g, b);

            // Output
            Hex_Copy.Text = HexText;
            Palette_Card.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
            Color_Text.Text = HexText;
            Color_Text.Visibility = System.Windows.Visibility.Visible;
            HSL_Copy.Text = HSLText;
            CMYK_Copy.Text = $"{cyan * 100:0.00},{magenta * 100:0.00},{yellow * 100:0.00},{black * 100:0.00}";
        }

        /// <summary>
        /// Hex => All
        /// </summary>
        /// <param name="HexStr"></param>
        private void ShowHexColor(string HexStr)
        {
            var Hex = HexStr.Trim('#');
            var r = int.Parse(Hex.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            var g = int.Parse(Hex.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            var b = int.Parse(Hex.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            // HLS
            RGBColorConverter.RGBToHSL(r, g, b, out var h, out var s, out var l);
            var HSLText = $"{h:0.00},{s:P},{l:P}";

            // CMYK
            (var cyan, var magenta, var yellow, var black) = RGBColorConverter.RGBToCMYK(r, g, b);

            // Output
            RGB_BOX_R.Text = r.ToString();
            RGB_BOX_G.Text = g.ToString();
            RGB_BOX_B.Text = b.ToString();
            Hex_Copy.Text = HexStr.ToUpper();
            Palette_Card.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
            Color_Text.Text = HexStr.ToUpper();
            Color_Text.Visibility = System.Windows.Visibility.Visible;
            HSL_Copy.Text = HSLText;
            CMYK_Copy.Text = $"{cyan * 100:0.00},{magenta * 100:0.00},{yellow * 100:0.00},{black * 100:0.00}";
        }

        /// <summary>
        /// HSL => All
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="l"></param>
        private void ShowHSLColor(double h, double s, double l)
        {
            RGBColorConverter.HSLToRGB(h, s, l, out var r, out var g, out var b);

            // Hex
            var HexText = $"#{r:X2}{g:X2}{b:X2}";

            // CMYK
            (var cyan, var magenta, var yellow, var black) = RGBColorConverter.RGBToCMYK(r, g, b);

            // Output
            RGB_BOX_R.Text = r.ToString();
            RGB_BOX_G.Text = g.ToString();
            RGB_BOX_B.Text = b.ToString();
            Hex_Copy.Text = HexText;
            Palette_Card.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
            Color_Text.Text = HexText;
            Color_Text.Visibility = System.Windows.Visibility.Visible;
            CMYK_Copy.Text = $"{cyan * 100:0.00},{magenta * 100:0.00},{yellow * 100:0.00},{black * 100:0.00}";
        }

        private void ShowCMYKColor(double cyan, double magenta, double yellow, double black)
        {
            (var r, var g, var b) = RGBColorConverter.CMYKToRGB(cyan, magenta, yellow, black);
            // Hex
            var HexText = $"#{r:X2}{g:X2}{b:X2}";

            // HLS
            RGBColorConverter.RGBToHSL(r, g, b, out var h, out var s, out var l);
            var HSLText = $"{h:0.00},{s:P},{l:P}";

            // Output
            RGB_BOX_R.Text = r.ToString();
            RGB_BOX_G.Text = g.ToString();
            RGB_BOX_B.Text = b.ToString();
            Hex_Copy.Text = HexText;
            Palette_Card.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
            Color_Text.Text = HexText;
            Color_Text.Visibility = System.Windows.Visibility.Visible;
            HSL_Copy.Text = HSLText;
        }

        /// <summary>
        /// Popular Color Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopularColorChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }

        private void Handle()
        {
            var hexStr = Popular_Color_Box.SelectedIndex switch
            {
                0 => "#7BC4C4",
                1 => "#E2583E",
                2 => "#53B0AE",
                3 => "#DECDBE",
                4 => "#9B1B30",
                5 => "#5A5B9F",
                6 => "#F0C05A",
                7 => "#45B5AA",
                8 => "#D94F70",
                9 => "#DD4124",
                10 => "#009473",
                11 => "#B163A3",
                12 => "#955251",
                13 => "#92A8D1",
                14 => "#F7CAC9",
                15 => "#88B04B",
                16 => "#5F4B8B",
                17 => "#FF6F61",
                18 => "#0F4C81",
                19 => "#939597",
                20 => "#F5DF4D",
                21 => "#696AAD",
                _ => "#FFFFFF"
            };
            ShowHexColor(hexStr);
        }
    }
}
