using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulePicker
{
    public class Schedule : Complete
    {
        public DateTime Horary { get; set; }
        public string Day { get; set; }
    }
}
