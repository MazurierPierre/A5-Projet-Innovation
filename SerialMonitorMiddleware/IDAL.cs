using System;
using System.Collections.Generic;
using System.Text;

namespace SerialMonitorMiddleware {
    interface IDAL {
        bool addSensor(ISensor sensor);
        bool addRecord(ISensor sensor, IRecord record);
        ISensor getSensor(int id);
        IRecord getRecord(int id);
    }
}
