using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    internal class ColorMap
    {
        private Color[] colorMap;
        public int numberOfColors { get; private set; }

        public ColorMap(Color[] colorArray)
        {
            this.colorMap = colorArray;
            this.numberOfColors = colorMap.Length;
        }

        public Color getColorFromIndex(int index)
        {
            return colorMap[index];
        }
        public int getIndexFromColor(Color color)
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