using System;
using System.Collections.Generic;
using System.Text;

namespace SerialMonitorMiddleware {
    interface IRecord {
        float value { get; set; }
        DateTime recordedAt { get; set; }
    }
}
