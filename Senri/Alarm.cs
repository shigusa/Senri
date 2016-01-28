using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Senri
{

    public enum config
    {
        Behavior,
        Time,
        Week,
    }
    public class Alarm
    {
        public string Behavior { get; set; }
        public string Time { get; set; }
        public string Week { get; set; }
    }
}
