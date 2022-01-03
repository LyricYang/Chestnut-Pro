using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chestnut_Pro.Model
{
    public class ChartModel
    {
        public ChartModel(DateTime dateTime, int v)
        {
            DateTime = dateTime;
            this.Value = v;
        }

        public DateTime DateTime { get; set; }

        public int Value { get; set; }
    }
}
