using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace wpf4
{
    public class Color_item
    {
        public string Hex { get; set; }
        public SolidColorBrush Color { get; set; }
        public Color_item(Color color)
        {
            Hex = "#";
            Hex += color.A.ToString("X2");
            Hex += color.R.ToString("X2");
            Hex += color.G.ToString("X2");
            Hex += color.B.ToString("X2");
            Color = new SolidColorBrush(color);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return this.Hex == (obj as Color_item).Hex;
        }
        public override int GetHashCode()
        {
            return Hex.GetHashCode();
        }
    }
}
