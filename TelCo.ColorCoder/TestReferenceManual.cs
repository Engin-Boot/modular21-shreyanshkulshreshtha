using System.Diagnostics;
using TelCo.WireColoringSystem;

namespace TelCo.TestWireColoringSystem
{
    class TestFunctionalities
    {
        static public void ValidateReferenceManual(string referenceManualString)
        {
            int totalCalculatedPairNum = ColorCoder.colorMapMajorLength * ColorCoder.colorMapMinorLength;
            string[] lines = referenceManualString.Split('\n');

            string[] headerCols = lines[0].Split('|');
            Debug.Assert(headerCols[0].Trim().Equals("Code") &&
                headerCols[1].Trim().Equals("Major Color") &&
                headerCols[2].Trim().Equals("Minor Color"));

            int lastCalculatedPairNum = 0;
            for (int calculatedPairNum = 1; calculatedPairNum <= totalCalculatedPairNum; ++calculatedPairNum)
            {
                lastCalculatedPairNum = calculatedPairNum;
                int lineNum = calculatedPairNum + 1;
                if (lines[lineNum].Equals("")) break;

                string[] fields = lines[lineNum].Split('|');
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