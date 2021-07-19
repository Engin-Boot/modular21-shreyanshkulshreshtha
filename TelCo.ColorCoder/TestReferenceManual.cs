using System.Diagnostics;
using TelCo.WireColoringSystem;
using TelCo.ReferenceManualUtils;

namespace TelCo.TestWireColoringSystem
{
    public class TestReferenceManual
    {
        public static void Validate(ManualReceiver receiver)
        {
            int totalCalculatedPairNum = ColorCoder.colorMapMajorLength * ColorCoder.colorMapMinorLength;
            string[] headerCols = receiver.Header.Split('|');
            Debug.Assert(headerCols[0].Trim().Equals("Code") &&
                headerCols[1].Trim().Equals("Major Color") &&
                headerCols[2].Trim().Equals("Minor Color"));

            string[] manualEntries = receiver.ManualEntries.Split('\n');

            int lastCalculatedPairNum = 0;
            for (int calculatedPairNum = 1; calculatedPairNum <= totalCalculatedPairNum; ++calculatedPairNum)
            {
                lastCalculatedPairNum = calculatedPairNum;
                int lineNum = calculatedPairNum - 1;
                if (manualEntries[lineNum].Equals("")) break;

                string[] fields = manualEntries[lineNum].Split('|');
                int pairNum = int.Parse(fields[0].Trim());
                string majorColor = fields[1].Trim();
                string minorColor = fields[2].Trim();

                string calculatedMajorColor = ColorCoder.GetColorFromPairNumber(pairNum).majorColor.Name;
                string calculatedMinorColor = ColorCoder.GetColorFromPairNumber(pairNum).minorColor.Name;

                Debug.Assert(majorColor.Equals(calculatedMajorColor) && minorColor.Equals(calculatedMinorColor));
            }

            Debug.Assert(lastCalculatedPairNum == totalCalculatedPairNum);
        }
    }
}