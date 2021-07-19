using System.Drawing;
using System.Text;
using TelCo.ReferenceManualUtils;

namespace TelCo.WireColoringSystem
{
    public class ColorCoder
    {
        private static ColorMap colorMapMajor;
        private static ColorMap colorMapMinor;

        public static int colorMapMajorLength { get => colorMapMajor.numberOfColors; }
        public static int colorMapMinorLength { get => colorMapMinor.numberOfColors; }

        static ColorCoder()
        {
            colorMapMajor = new ColorMap(new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet });
            colorMapMinor = new ColorMap(new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray });
            ColorEncoderDecoder.colorMapMajor = colorMapMajor;
            ColorEncoderDecoder.colorMapMinor = colorMapMinor;
        }

        public static void PrintReferenceManual(IManualReceiver receiver)
        {
            int counter = 1;
            receiver.write($"{"Code".PadRight(5).Substring(0, 5)}|  {"Major Color".PadRight(13).Substring(0, 13)}|  {"Minor Color".PadRight(13).Substring(0, 13)}\n");
            receiver.write($"{"".PadRight(5, '-')}+{"".PadRight(15, '-')}+{"".PadRight(15, '-')}\n");
            for (int i = 0; i < colorMapMajor.numberOfColors; ++i)
            {
                for (int j = 0; j < colorMapMinor.numberOfColors; ++j)
                {
                    receiver.write($" {(counter++).ToString().PadRight(4).Substring(0, 4)}|  ");
                    receiver.write($"{colorMapMajor.getColorFromIndex(i).Name.PadRight(13).Substring(0, 13)}|  ");
                    receiver.write($"{colorMapMinor.getColorFromIndex(j).Name.PadRight(13).Substring(0, 13)}\n");
                }
            }
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
