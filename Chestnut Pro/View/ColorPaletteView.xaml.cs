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
            Palette_Card.Background = new SolidColorBrush(Color.FromRgb(255,255,255));
        }

        private void ColorButton0000(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0000.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0001(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0001.ToolTip.ToString();
            ShowHexColor(hex);
        }


        private void ColorButton0002(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0002.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0003(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0003.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0004(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0004.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0005(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0005.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0006(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0006.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0007(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0007.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0008(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0008.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0009(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0009.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0010(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0010.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0011(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0011.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0012(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0012.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0013(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0013.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0014(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0014.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0015(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0015.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0016(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0016.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0017(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0017.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0018(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0018.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0019(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0019.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0020(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0020.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0021(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0021.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0022(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0022.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0023(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0023.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0024(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0024.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0025(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0025.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0026(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0026.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0027(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0027.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0028(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0028.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0029(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0029.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0030(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0030.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0031(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0031.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0032(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0032.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0033(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0033.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0034(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0034.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0035(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0035.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0036(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0036.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0037(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0037.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0038(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0038.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0039(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0039.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0040(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0040.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0041(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0041.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0042(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0042.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0043(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0043.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0044(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0044.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0045(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0045.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0046(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0046.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0047(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0047.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0048(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0048.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0049(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0049.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0050(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0050.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0051(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0051.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0052(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0052.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0053(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0053.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0054(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0054.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0055(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0055.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0056(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0056.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0057(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0057.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0058(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0058.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0059(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0059.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0060(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0060.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0061(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0061.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0062(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0062.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0063(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0063.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0064(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0064.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0065(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0065.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0066(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0066.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0067(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0067.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0068(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0068.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0069(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0069.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0070(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0070.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0071(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0071.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0072(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0072.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0073(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0073.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0074(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0074.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0075(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0075.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0076(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0076.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0077(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0077.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0078(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0078.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0079(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0079.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0080(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0080.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0081(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0081.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0082(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0082.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0083(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0083.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0084(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0084.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0085(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0085.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0086(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0086.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0087(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0087.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0088(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0088.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0089(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0089.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0090(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0090.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0091(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0091.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0092(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0092.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0093(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0093.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0094(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0094.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0095(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0095.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0096(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0096.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0097(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0097.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0098(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0098.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0099(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0099.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0100(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0100.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0101(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0101.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0102(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0102.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0103(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0103.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0104(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0104.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0105(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0105.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0106(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0106.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0107(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0107.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0108(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0108.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0109(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0109.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0110(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0110.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0111(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0111.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0112(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0112.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0113(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0113.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0114(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0114.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0115(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0115.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0116(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0116.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0117(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0117.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0118(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0118.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0119(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0119.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0120(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0120.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0121(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0121.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0122(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0122.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0123(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0123.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0124(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0124.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0125(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0125.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0126(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0126.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0127(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0127.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0128(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0128.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0129(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0129.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0130(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0130.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0131(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0131.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0132(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0132.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0133(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0133.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0134(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0134.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0135(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0135.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0136(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0136.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0137(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0137.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0138(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0138.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0139(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0139.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0140(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0140.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0141(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0141.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0142(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0142.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0143(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0143.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0144(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0144.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0145(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0145.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0146(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0146.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0147(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0147.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0148(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0148.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0149(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0149.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0150(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0150.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0151(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0151.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0152(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0152.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0153(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0153.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0154(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0154.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0155(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0155.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0156(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0156.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0157(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0157.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0158(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0158.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0159(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0159.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0160(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0160.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0161(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0161.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0162(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0162.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0163(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0163.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0164(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0164.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0165(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0165.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0166(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0166.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0167(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0167.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0168(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0168.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0169(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0169.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0170(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0170.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0171(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0171.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0172(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0172.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0173(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0173.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0174(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0174.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0175(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0175.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0176(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0176.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0177(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0177.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0178(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0178.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0179(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0179.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0180(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0180.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0181(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0181.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0182(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0182.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0183(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0183.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0184(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0184.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0185(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0185.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0186(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0186.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0187(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0187.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0188(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0188.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0189(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0189.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0190(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0190.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0191(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0191.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0192(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0192.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0193(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0193.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0194(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0194.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0195(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0195.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0196(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0196.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0197(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0197.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0198(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0198.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0199(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0199.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0200(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0200.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0201(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0201.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0202(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0202.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0203(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0203.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0204(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0204.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0205(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0205.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0206(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0206.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0207(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0207.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0208(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0208.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0209(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0209.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0210(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0210.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0211(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0211.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0212(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0212.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0213(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0213.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0214(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0214.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0215(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0215.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0216(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0216.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0217(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0217.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0218(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0218.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0219(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0219.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0220(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0220.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0221(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0221.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0222(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0222.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0223(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0223.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0224(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0224.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0225(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0225.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0226(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0226.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0227(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0227.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0228(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0228.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0229(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0229.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0230(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0230.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0231(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0231.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0232(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0232.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0233(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0233.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0234(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0234.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0235(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0235.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0236(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0236.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0237(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0237.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0238(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0238.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0239(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0239.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0240(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0240.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0241(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0241.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0242(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0242.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0243(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0243.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0244(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0244.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0245(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0245.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0246(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0246.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0247(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0247.ToolTip.ToString();
            ShowHexColor(hex);
        }


        private void ColorButton0248(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0248.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0249(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0249.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0250(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0250.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0251(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0251.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0252(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0252.ToolTip.ToString();
            ShowHexColor(hex);
        }

        private void ColorButton0253(object sender, System.Windows.RoutedEventArgs e)
        {
            var hex = Color_Button_0253.ToolTip.ToString();
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
