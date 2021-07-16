using System.Drawing;

namespace TelCo.WireColoringSystem
{
    internal class ColorMap
    {
        private Color[] colorMap;
        internal int numberOfColors { get; private set; }

        internal ColorMap(Color[] colorArray)
        {
            this.colorMap = colorArray;
            this.numberOfColors = colorMap.Length;
        }

        internal Color getColorFromIndex(int index)
        {
            return colorMap[index];
        }
        internal int getIndexFromColor(Color color)
        {
            int index = -1;
            for (int i = 0; i < colorMap.Length; i++)
            {
                if (colorMap[i] == color)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}