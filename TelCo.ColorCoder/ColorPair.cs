using System.Drawing;

namespace TelCo.WireColoringSystem
{
    public class ColorPair
    {
        public Color majorColor { get; set; }
        public Color minorColor { get; set; }
        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);   
        }
    }
}