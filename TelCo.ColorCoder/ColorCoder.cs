using System;
using System.Drawing;

namespace TelCo.ColorCoder
{
    class ColorCoder
    {
        private static ColorMap colorMapMajor;
        private static ColorMap colorMapMinor;
        static ColorCoder()
        {
            colorMapMajor = new ColorMap(new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet });
            colorMapMinor = new ColorMap(new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray });
        }

        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int minorMapSize = colorMapMinor.numberOfColors;
            int majorMapSize = colorMapMajor.numberOfColors;
            if (pairNumber < 1 || pairNumber > minorMapSize * majorMapSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorMapSize;
            int minorIndex = zeroBasedPairNumber % minorMapSize;

            ColorPair pair = new ColorPair()
            {
                majorColor = colorMapMajor.getColorFromIndex(majorIndex),
                minorColor = colorMapMinor.getColorFromIndex(minorIndex)
            };

            return pair;
        }
        public static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = colorMapMajor.getIndexFromColor(pair.majorColor);
            int minorIndex = colorMapMinor.getIndexFromColor(pair.minorColor);
            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            return (majorIndex * colorMapMinor.numberOfColors) + (minorIndex + 1);
        }
    }
}
