﻿namespace Chestnut_Pro.ViewModel
{
    using Chestnut_Pro.Model;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Color Palette View Model
    /// </summary>
    public class ColorPaletteViewModel : ViewModelBase
    {
        public ObservableCollection<HeaderModel> PaletteColumnHeadersCollection { get; set; }

        public ObservableCollection<HeaderModel> PaletteRowHeadersCollection { get; set; }

        public ObservableCollection<ColorModel> PaletteColorsRow1Collection { get; set; }

        public ObservableCollection<ColorModel> PaletteColorsRow2Collection { get; set; }

        /// <summary>
        /// The Constructor
        /// </summary>
        public ColorPaletteViewModel()
        {
            PaletteColumnHeadersCollection = new()
            {
                new() { HeaderName = "50" },
                new() { HeaderName = "100" },
                new() { HeaderName = "200" },
                new() { HeaderName = "300" },
                new() { HeaderName = "400" },
                new() { HeaderName = "500" },
                new() { HeaderName = "600" },
                new() { HeaderName = "700" },
                new() { HeaderName = "800" },
                new() { HeaderName = "900" },
                new() { HeaderName = "A100" },
                new() { HeaderName = "A200" },
                new() { HeaderName = "A400" },
                new() { HeaderName = "A700" },
            };

            PaletteRowHeadersCollection = new()
            {
                new() { HeaderName = "Red" },
                new() { HeaderName = "Pink" },
                new() { HeaderName = "Purple" },
                new() { HeaderName = "Deep Purple" },
                new() { HeaderName = "Indigo" },
                new() { HeaderName = "Blue" },
                new() { HeaderName = "Light Blue" },
                new() { HeaderName = "Cyan" },
                new() { HeaderName = "Teal" },
                new() { HeaderName = "Green" },
                new() { HeaderName = "Light Green" },
                new() { HeaderName = "Lime" },
                new() { HeaderName = "Yellow" },
                new() { HeaderName = "Amber" },
                new() { HeaderName = "Orange" },
                new() { HeaderName = "Deep Orange" },
                new() { HeaderName = "Brown" },
                new() { HeaderName = "Grey" },
                new() { HeaderName = "Blue Grey" },
            };

            PaletteColorsRow1Collection = new()
            {
                new() { ColorHex = "#ffebee" },
                new() { ColorHex = "#ffcdd2" },
                new() { ColorHex = "#ef9a9a" },
                new() { ColorHex = "#e57373" },
                new() { ColorHex = "#ef5350" },
                new() { ColorHex = "#f44336" },
                new() { ColorHex = "#e53935" },
                new() { ColorHex = "#d32f2f" },
                new() { ColorHex = "#c62828" },
                new() { ColorHex = "#b71c1c" },
                new() { ColorHex = "#ff8a80" },
                new() { ColorHex = "#ff5252" },
                new() { ColorHex = "#ff1744" },
                new() { ColorHex = "#d50000" },
                new() { ColorHex = "#fce4ec" },
                new() { ColorHex = "#f8bbd0" },
                new() { ColorHex = "#f48fb1" },
                new() { ColorHex = "#f06292" },
                new() { ColorHex = "#ec407a" },
                new() { ColorHex = "#e91e63" },
                new() { ColorHex = "#d81b60" },
                new() { ColorHex = "#c2185b" },
                new() { ColorHex = "#ad1457" },
                new() { ColorHex = "#880e4f" },
                new() { ColorHex = "#ff80ab" },
                new() { ColorHex = "#ff4081" },
                new() { ColorHex = "#f50057" },
                new() { ColorHex = "#c51162" },
                new() { ColorHex = "#f3e5f5" },
                new() { ColorHex = "#e1bee7" },
                new() { ColorHex = "#ce93d8" },
                new() { ColorHex = "#ba68c8" },
                new() { ColorHex = "#ab47bc" },
                new() { ColorHex = "#9c27b0" },
                new() { ColorHex = "#8e24aa" },
                new() { ColorHex = "#7b1fa2" },
                new() { ColorHex = "#6a1b9a" },
                new() { ColorHex = "#4a148c" },
                new() { ColorHex = "#ea80fc" },
                new() { ColorHex = "#e040fb" },
                new() { ColorHex = "#d500f9" },
                new() { ColorHex = "#aa00ff" },
                new() { ColorHex = "#ede7f6" },
                new() { ColorHex = "#d1c4e9" },
                new() { ColorHex = "#b39ddb" },
                new() { ColorHex = "#9575cd" },
                new() { ColorHex = "#7e57c2" },
                new() { ColorHex = "#673ab7" },
                new() { ColorHex = "#5e35b1" },
                new() { ColorHex = "#512da8" },
                new() { ColorHex = "#4527a0" },
                new() { ColorHex = "#311b92" },
                new() { ColorHex = "#b388ff" },
                new() { ColorHex = "#7c4dff" },
                new() { ColorHex = "#651fff" },
                new() { ColorHex = "#6200ea" },
                new() { ColorHex = "#e8eaf6" },
                new() { ColorHex = "#c5cae9" },
                new() { ColorHex = "#9fa8da" },
                new() { ColorHex = "#7986cb" },
                new() { ColorHex = "#5c6bc0" },
                new() { ColorHex = "#3f51b5" },
                new() { ColorHex = "#3949ab" },
                new() { ColorHex = "#303f9f" },
                new() { ColorHex = "#283593" },
                new() { ColorHex = "#1a237e" },
                new() { ColorHex = "#8c9eff" },
                new() { ColorHex = "#536dfe" },
                new() { ColorHex = "#3d5afe" },
                new() { ColorHex = "#304ffe" },
                new() { ColorHex = "#e3f2fd" },
                new() { ColorHex = "#bbdefb" },
                new() { ColorHex = "#90caf9" },
                new() { ColorHex = "#64b5f6" },
                new() { ColorHex = "#42a5f5" },
                new() { ColorHex = "#2196f3" },
                new() { ColorHex = "#1e88e5" },
                new() { ColorHex = "#1976d2" },
                new() { ColorHex = "#1565c0" },
                new() { ColorHex = "#0d47a1" },
                new() { ColorHex = "#82b1ff" },
                new() { ColorHex = "#448aff" },
                new() { ColorHex = "#2979ff" },
                new() { ColorHex = "#2962ff" },
                new() { ColorHex = "#e1f5fe" },
                new() { ColorHex = "#b3e5fc" },
                new() { ColorHex = "#81d4fa" },
                new() { ColorHex = "#4fc3f7" },
                new() { ColorHex = "#29b6f6" },
                new() { ColorHex = "#03a9f4" },
                new() { ColorHex = "#039be5" },
                new() { ColorHex = "#0288d1" },
                new() { ColorHex = "#0277bd" },
                new() { ColorHex = "#01579b" },
                new() { ColorHex = "#80d8ff" },
                new() { ColorHex = "#40c4ff" },
                new() { ColorHex = "#00b0ff" },
                new() { ColorHex = "#0091ea" },
                new() { ColorHex = "#e0f7fa" },
                new() { ColorHex = "#b2ebf2" },
                new() { ColorHex = "#80deea" },
                new() { ColorHex = "#4dd0e1" },
                new() { ColorHex = "#26c6da" },
                new() { ColorHex = "#00bcd4" },
                new() { ColorHex = "#00acc1" },
                new() { ColorHex = "#0097a7" },
                new() { ColorHex = "#00838f" },
                new() { ColorHex = "#006064" },
                new() { ColorHex = "#84ffff" },
                new() { ColorHex = "#18ffff" },
                new() { ColorHex = "#00e5ff" },
                new() { ColorHex = "#00b8d4" },
                new() { ColorHex = "#e0f2f1" },
                new() { ColorHex = "#b2dfdb" },
                new() { ColorHex = "#80cbc4" },
                new() { ColorHex = "#4db6ac" },
                new() { ColorHex = "#26a69a" },
                new() { ColorHex = "#009688" },
                new() { ColorHex = "#00897b" },
                new() { ColorHex = "#00796b" },
                new() { ColorHex = "#00695c" },
                new() { ColorHex = "#004d40" },
                new() { ColorHex = "#a7ffeb" },
                new() { ColorHex = "#64ffda" },
                new() { ColorHex = "#1de9b6" },
                new() { ColorHex = "#00bfa5" },
                new() { ColorHex = "#e8f5e9" },
                new() { ColorHex = "#c8e6c9" },
                new() { ColorHex = "#a5d6a7" },
                new() { ColorHex = "#81c784" },
                new() { ColorHex = "#66bb6a" },
                new() { ColorHex = "#4caf50" },
                new() { ColorHex = "#43a047" },
                new() { ColorHex = "#388e3c" },
                new() { ColorHex = "#2e7d32" },
                new() { ColorHex = "#1b5e20" },
                new() { ColorHex = "#b9f6ca" },
                new() { ColorHex = "#69f0ae" },
                new() { ColorHex = "#00e676" },
                new() { ColorHex = "#00c853" },
                new() { ColorHex = "#f1f8e9" },
                new() { ColorHex = "#dcedc8" },
                new() { ColorHex = "#c5e1a5" },
                new() { ColorHex = "#aed581" },
                new() { ColorHex = "#9ccc65" },
                new() { ColorHex = "#8bc34a" },
                new() { ColorHex = "#7cb342" },
                new() { ColorHex = "#689f38" },
                new() { ColorHex = "#558b2f" },
                new() { ColorHex = "#33691e" },
                new() { ColorHex = "#ccff90" },
                new() { ColorHex = "#b2ff59" },
                new() { ColorHex = "#76ff03" },
                new() { ColorHex = "#64dd17" },
                new() { ColorHex = "#f9fbe7" },
                new() { ColorHex = "#f0f4c3" },
                new() { ColorHex = "#e6ee9c" },
                new() { ColorHex = "#dce775" },
                new() { ColorHex = "#d4e157" },
                new() { ColorHex = "#cddc39" },
                new() { ColorHex = "#c0ca33" },
                new() { ColorHex = "#afb42b" },
                new() { ColorHex = "#9e9d24" },
                new() { ColorHex = "#827717" },
                new() { ColorHex = "#f4ff81" },
                new() { ColorHex = "#eeff41" },
                new() { ColorHex = "#c6ff00" },
                new() { ColorHex = "#aeea00" },
                new() { ColorHex = "#fffde7" },
                new() { ColorHex = "#fff9c4" },
                new() { ColorHex = "#fff59d" },
                new() { ColorHex = "#fff176" },
                new() { ColorHex = "#ffee58" },
                new() { ColorHex = "#ffeb3b" },
                new() { ColorHex = "#fdd835" },
                new() { ColorHex = "#fbc02d" },
                new() { ColorHex = "#f9a825" },
                new() { ColorHex = "#f57f17" },
                new() { ColorHex = "#ffff8d" },
                new() { ColorHex = "#ffff00" },
                new() { ColorHex = "#ffea00" },
                new() { ColorHex = "#ffd600" },
                new() { ColorHex = "#fff8e1" },
                new() { ColorHex = "#ffecb3" },
                new() { ColorHex = "#ffe082" },
                new() { ColorHex = "#ffd54f" },
                new() { ColorHex = "#ffca28" },
                new() { ColorHex = "#ffc107" },
                new() { ColorHex = "#ffb300" },
                new() { ColorHex = "#ffa000" },
                new() { ColorHex = "#ff8f00" },
                new() { ColorHex = "#ff6f00" },
                new() { ColorHex = "#ffe57f" },
                new() { ColorHex = "#ffd740" },
                new() { ColorHex = "#ffc400" },
                new() { ColorHex = "#ffab00" },
                new() { ColorHex = "#fff3e0" },
                new() { ColorHex = "#ffe0b2" },
                new() { ColorHex = "#ffcc80" },
                new() { ColorHex = "#ffb74d" },
                new() { ColorHex = "#ffa726" },
                new() { ColorHex = "#ff9800" },
                new() { ColorHex = "#fb8c00" },
                new() { ColorHex = "#f57c00" },
                new() { ColorHex = "#ef6c00" },
                new() { ColorHex = "#e65100" },
                new() { ColorHex = "#ffd180" },
                new() { ColorHex = "#ffab40" },
                new() { ColorHex = "#ff9100" },
                new() { ColorHex = "#ff6d00" },
                new() { ColorHex = "#fbe9e7" },
                new() { ColorHex = "#ffccbc" },
                new() { ColorHex = "#ffab91" },
                new() { ColorHex = "#ff8a65" },
                new() { ColorHex = "#ff7043" },
                new() { ColorHex = "#ff5722" },
                new() { ColorHex = "#f4511e" },
                new() { ColorHex = "#e64a19" },
                new() { ColorHex = "#d84315" },
                new() { ColorHex = "#bf360c" },
                new() { ColorHex = "#ff9e80" },
                new() { ColorHex = "#ff6e40" },
                new() { ColorHex = "#ff3d00" },
                new() { ColorHex = "#dd2c00" },
            };

            PaletteColorsRow2Collection = new()
            {
                new() { ColorHex = "#efebe9" },
                new() { ColorHex = "#d7ccc8" },
                new() { ColorHex = "#bcaaa4" },
                new() { ColorHex = "#a1887f" },
                new() { ColorHex = "#8d6e63" },
                new() { ColorHex = "#795548" },
                new() { ColorHex = "#6d4c41" },
                new() { ColorHex = "#5d4037" },
                new() { ColorHex = "#4e342e" },
                new() { ColorHex = "#3e2723" },
                new() { ColorHex = "#fafafa" },
                new() { ColorHex = "#f5f5f5" },
                new() { ColorHex = "#eeeeee" },
                new() { ColorHex = "#e0e0e0" },
                new() { ColorHex = "#bdbdbd" },
                new() { ColorHex = "#9e9e9e" },
                new() { ColorHex = "#757575" },
                new() { ColorHex = "#616161" },
                new() { ColorHex = "#424242" },
                new() { ColorHex = "#212121" },
                new() { ColorHex = "#eceff1" },
                new() { ColorHex = "#cfd8dc" },
                new() { ColorHex = "#b0bec5" },
                new() { ColorHex = "#90a4ae" },
                new() { ColorHex = "#78909c" },
                new() { ColorHex = "#607d8b" },
                new() { ColorHex = "#546e7a" },
                new() { ColorHex = "#455a64" },
                new() { ColorHex = "#37474f" },
                new() { ColorHex = "#263238" },
            };
        }
    }
}
