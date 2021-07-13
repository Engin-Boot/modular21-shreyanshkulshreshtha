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
            ColorEncoderDecoder.colorMapMajor = colorMapMajor;
            ColorEncoderDecoder.colorMapMinor = colorMapMinor;
        }

        public static void printReferenceManual()
        {
            int counter = 1;
            Console.WriteLine("This is the reference manual for the 25-pair color code");
            Console.WriteLine("\n".PadLeft(55, '='));
            Console.WriteLine("{0}|  {1}|  {2}", "Code".PadRight(5).Substring(0, 5), "Major Color".PadRight(13).Substring(0, 13), "Minor Color".PadRight(13).Substring(0, 13));
            Console.WriteLine("{0}+{1}+{2}", "".PadRight(5, '-'), "".PadRight(15, '-'), "".PadRight(15, '-'));
            for (int i = 0; i < colorMapMajor.numberOfColors; ++i)
            {
                for (int j = 0; j < colorMapMinor.numberOfColors; ++j)
                {
                    Console.WriteLine(" {0}|  {1}|  {2}", (counter++).ToString().PadRight(4).Substring(0, 4),
                        colorMapMajor.getColorFromIndex(i).Name.PadRight(13).Substring(0, 13),
                        colorMapMinor.getColorFromIndex(j).Name.PadRight(13).Substring(0, 13));
                }
            }
            Console.WriteLine("");
        }

        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int zeroBasedPairNumber = pairNumber - 1;
            return ColorEncoderDecoder.DecodeNumber(zeroBasedPairNumber);
        }

        public static int GetPairNumberFromColor(ColorPair colorPair)
        {
            return ColorEncoderDecoder.EncodeColor(colorPair);
        }
    }
}
