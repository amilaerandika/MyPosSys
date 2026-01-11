using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPosSys.Data
{
    using System;
    using System.Drawing.Printing;
    using System.Text;

    public class ThermalPrinter
    {
        private StringBuilder _sb = new StringBuilder();

        // ESC/POS commands
        private const string ESC = "\x1B";
        private const string GS = "\x1D";

        public void Initialize()
        {
            _sb.Append(ESC + "@"); // Init
        }

        public void Center()
        {
            _sb.Append(ESC + "a" + "\x01");
        }

        public void Left()
        {
            _sb.Append(ESC + "a" + "\x00");
        }

        public void BoldOn()
        {
            _sb.Append(ESC + "E" + "\x01");
        }

        public void BoldOff()
        {
            _sb.Append(ESC + "E" + "\x00");
        }

        public void NewLine()
        {
            _sb.Append("\n");
        }

        public void Text(string text)
        {
            _sb.Append(text);
        }

        public void Cut()
        {
            _sb.Append(GS + "V" + "\x01");
        }

        public byte[] GetBytes()
        {
            return Encoding.ASCII.GetBytes(_sb.ToString());
        }
    }

}
