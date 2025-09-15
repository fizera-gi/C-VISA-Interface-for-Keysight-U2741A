using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisaComLib;

namespace Test_U2741A
{
    public sealed class CentraleMesure : IDisposable
    {
        private readonly ResourceManager _rm = new ResourceManager();
        private readonly FormattedIO488 _io = new FormattedIO488();
        private bool _opened;

        public CentraleMesure(string visaAddress)
        {
            // OuvreVISA
            _io.IO = (IMessage)_rm.Open(visaAddress, AccessMode.NO_LOCK, 5000, "");
            _opened = true;

            var msg = (IMessage)_io.IO;
            msg.Timeout = 10000;                        // 10s
            msg.TerminationCharacter = 0x0A;            // LF
            msg.TerminationCharacterEnabled = true;
            msg.SendEndEnabled = true;

            // Reset & Clear
            _io.WriteString("*RST\n", true);
            _io.WriteString("*CLS\n", true);
        }

        public string Idn()
        {
            var msg = (IMessage)_io.IO;
            msg.Timeout = 10000;                   // 10 secondes
            msg.TerminationCharacter = 0x0A;       // LF
            msg.TerminationCharacterEnabled = true;
            msg.SendEndEnabled = true;

            _io.WriteString("*IDN?\n", true);
            string idn = _io.ReadString();
            return idn;
        }


        public void ConfigureVdc(double range = 10, double nplc = 1.0, bool autoZero = false)
        {
            _io.WriteString($"CONF:VOLT:DC {range}\n", true);
            _io.WriteString($"VOLT:DC:NPLC {nplc}\n", true);
            _io.WriteString($"ZERO:AUTO {(autoZero ? "ON" : "OFF")}\n", true);
            _io.WriteString("TRIG:SOUR IMM\n", true);
            _io.WriteString("SAMP:COUN 1\n", true);
        }

        public double ReadVdc()
        {
            _io.WriteString("READ?\n", true);
            string s = _io.ReadString().Trim();
            return double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
        }

        public void ConfigureResistance(double range = 1000)
        {
            _io.WriteString($"CONF:RES {range}\n", true);
        }

        public double ReadResistance()
        {
            _io.WriteString("READ?\n", true);
            string s = _io.ReadString().Trim();
            return double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
        }

        public void Dispose()
        {
            if (_opened)
            {
                try { _io.IO.Close(); } catch { }
                _opened = false;
            }
        }
    }
}
