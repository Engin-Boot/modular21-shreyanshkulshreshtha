using System;

namespace TelCo.WireColoringSystem
{
    internal class ColorEncoderDecoder
    {
        internal static ColorMap colorMapMajor;
        internal static ColorMap colorMapMinor;

        internal static ColorPair DecodeNumber(int zeroBasedPairNumber)
        {
            int minorMapSize = colorMapMinor.numberOfColors;
            int majorMapSize = colorMapMajor.numberOfColors;
            if (zeroBasedPairNumber < 0 || zeroBasedPairNumber >= minorMapSize * majorMapSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", zeroBasedPairNumber));
            }

            int majorIndex = zeroBasedPairNumber / minorMapSize;
            int minorIndex = zeroBasedPairNumber % minorMapSize;

            ColorPair pair = new ColorPair()
            {
                majorColor = colorMapMajor.getColorFromIndex(majorIndex),
                minorColor = colorMapMinor.getColorFromIndex(minorIndex)
            };

            return pair;
        }

        internal static int EncodeColor(ColorPair pair)
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