namespace Chestnut_Pro.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Color Converter
    /// </summary>
    public class RGBColorConverter
    {
        // Convert an RGB value into an HLS value.
        public static void RGBToHSL(int r, int g, int b,
            out double h,  out double s, out double l)
        {
            // Convert RGB to a 0.0 to 1.0 range.
            double double_r = r / 255.0;
            double double_g = g / 255.0;
            double double_b = b / 255.0;

            // Get the maximum and minimum RGB components.
            double max = double_r;
            if (max < double_g) max = double_g;
            if (max < double_b) max = double_b;

            double min = double_r;
            if (min > double_g) min = double_g;
            if (min > double_b) min = double_b;

            double diff = max - min;
            l = (max + min) / 2;
            if (Math.Abs(diff) < 0.00001)
            {
                s = 0;
                h = 0;  // H is really undefined.
            }
            else
            {
                if (l <= 0.5) s = diff / (max + min);
                else s = diff / (2 - max - min);

                double r_dist = (max - double_r) / diff;
                double g_dist = (max - double_g) / diff;
                double b_dist = (max - double_b) / diff;

                if (double_r == max) h = b_dist - g_dist;
                else if (double_g == max) h = 2 + r_dist - b_dist;
                else h = 4 + g_dist - r_dist;

                h = h * 60;
                if (h < 0) h += 360;
            }
        }

        // Convert an HLS value into an RGB value.
        public static void HSLToRGB(double h, double s, double l,
            out int r, out int g, out int b)
        {
            double p2;
            if (l <= 0.5) p2 = l * (1 + s);
            else p2 = l + s - l * s;

            double p1 = 2 * l - p2;
            double double_r, double_g, double_b;
            if (s == 0)
            {
                double_r = l;
                double_g = l;
                double_b = l;
            }
            else
            {
                double_r = QQHToRGB(p1, p2, h + 120);
                double_g = QQHToRGB(p1, p2, h);
                double_b = QQHToRGB(p1, p2, h - 120);
            }

            // Convert RGB to the 0 to 255 range.
            r = (int)(double_r * 255.0);
            g = (int)(double_g * 255.0);
            b = (int)(double_b * 255.0);
        }

        /// <summary>
        /// RGB -> CMYK
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <returns></returns>
        public static (double, double, double, double) RGBToCMYK(int red, int green, int blue)
        {
            double black = Math.Min(1.0 - red / 255.0, Math.Min(1.0 - green / 255.0, 1.0 - blue / 255.0));
            double cyan = (1.0 - (red / 255.0) - black) / (1.0 - black);
            double magenta = (1.0 - (green / 255.0) - black) / (1.0 - black);
            double yellow = (1.0 - (blue / 255.0) - black) / (1.0 - black);
            return (cyan, magenta, yellow, black);
        }

        /// <summary>
        /// CMYK -> RGB
        /// </summary>
        /// <param name="cyan"></param>
        /// <param name="magenta"></param>
        /// <param name="yellow"></param>
        /// <param name="black"></param>
        /// <returns></returns>
        public static (int, int, int) CMYKToRGB(double cyan, double magenta, double yellow, double black)
        {
            int red = Convert.ToInt32((1 - Math.Min(1, cyan * (1 - black) + black)) * 255);
            int green = Convert.ToInt32((1 - Math.Min(1, magenta * (1 - black) + black)) * 255);
            int blue = Convert.ToInt32((1 - Math.Min(1, yellow * (1 - black) + black)) * 255);
            return (red, green, blue);
        }

        // QQH -> RGB
        private static double QQHToRGB(double q1, double q2, double hue)
        {
            if (hue > 360) hue -= 360;
            else if (hue < 0) hue += 360;

            if (hue < 60) return q1 + (q2 - q1) * hue / 60;
            if (hue < 180) return q2;
            if (hue < 240) return q1 + (q2 - q1) * (240 - hue) / 60;
            return q1;
        }
    }
}
