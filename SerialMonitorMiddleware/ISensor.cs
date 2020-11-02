using System;
using System.Collections.Generic;
using System.Text;

namespace SerialMonitorMiddleware {
    interface ISensor {
        int id { get; set; }
        string name { get; set; }
        IRecord[] records { get; set; }
    }
}
