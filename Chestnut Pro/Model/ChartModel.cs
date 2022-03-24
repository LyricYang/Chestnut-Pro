using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chestnut_Pro.Model
{
    public class ChartModel
    {
        public ChartModel(string source, string destination, int v)
        {
            this.Source = source;
            this.Destination = destination;
            this.Value = v;
        }

        public string Source { get; set; }

        public string Destination { get; set; }

        public int Value { get; set; }

        public bool Visiable { get; set; } = true;
    }
}
