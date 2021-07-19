using System;
using System.Text;

namespace TelCo.ReferenceManualUtils
{
    public interface IManualReceiver
    {
        void write(string str);
    }

    public class ConsoleWrapper : IManualReceiver
    {
        public void write(string str) { Console.Write(str); }
    }

    public class ManualReceiver : IManualReceiver
    {
        private string header;
        private bool readSeparator;
        private StringBuilder manualEntriesCollector;

        public string Header { get { return header; } }
        public string ManualEntries { get { return manualEntriesCollector.ToString(); } }

        public ManualReceiver()
        {
            header = null;
            readSeparator = false;
            manualEntriesCollector = new StringBuilder();
        }

        public void write(string str)
        {
            if (header == null) header = str;
            else if (readSeparator == false) readSeparator = true;
            else manualEntriesCollector.Append(str);
        }
    }

}